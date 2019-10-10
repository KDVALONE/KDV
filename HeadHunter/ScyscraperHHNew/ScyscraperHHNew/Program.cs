using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ScyscraperHHNew
{
    class Program
    {
        static void Main(string[] args)
        {
            ScyScrapper sc = new ScyScrapper();
            List<int> clues = new List<int> { 0, 0, 0, 2, 2, 0, 0, 0, 0, 6, 3, 0, 0, 4, 0, 0, 0, 0, 4, 4, 0, 3, 0, 0 };
           // List<int> clues = new List<int> { 4, 1, 0, 4, 0, 0, 2, 0, 0, 3, 0, 0, 3, 0, 3, 0, 5, 0, 4, 0, 0, 4, 0, 2 };
            List<List<int>> rez = new List<List<int>>();
            rez.AddRange(sc.solvePuzzle(clues));
            //Debugger.Break();
            foreach (var e in rez)
            {
                foreach (var eIn in e)
                {
                    Console.Write(eIn);
                    Console.Write(',');
                }
            }
            Console.ReadKey();
        }
    }


    class ScyScrapper
    {
        const int N = 6;
        const int SIDES = 4;
        private const int MASK = (1 << N) - 1;
        int[] possible = new int[N * N];
        int[] s = new int[SIDES * N];
        int[] e = new int[SIDES * N];
        int[] inc = new int[SIDES * N];
        int[,] results = new int[N, N];

        List<int> my_clues;
        List<int> order = new List<int>();

        void set_value(int x, int v)
        {
            Console.WriteLine("set_value****************************************************\n");
            int m = MASK ^ (1 << v);
            int s_row = x - x % N;
            int s_col = x % N;
            for (int i = 0; i < N; i++)
            {
                possible[s_row + i] &= m;
                possible[s_col + i * N] &= m;
            }
            possible[x] = 1 << v;
        }
        int check_unique()
        {
            Console.WriteLine("check_unique****************************************************\n");
            int n_decides = 0;
            for (int i = 0; i < SIDES / 2 * N; i++)
            {

                Dictionary<int, List<int>> possible_indices = new Dictionary<int, List<int>>();
                for (int j = s[i], k = 0; k < N; j += inc[i], k++)
                {
                    for (int l = 0; l < N; l++)
                        if (((1 << l) & possible[j]) != 0)
                        {
                            if (!possible_indices.ContainsKey(l))
                            {
                                possible_indices.Add(l, new List<int>());
                            }

                            possible_indices[l].Add(j);
                        }
                }

                foreach (KeyValuePair<int, List<int>> iter in possible_indices)
                { //for (auto const& iter : possible_indices)
                    int val = iter.Key;
                    if (iter.Value.Count == 1)
                    {
                        int idx = iter.Value[0];
                        if (possible[idx] != (1 << val))
                        {
                            n_decides++;
                            set_value(idx, val);
                        }
                    }
                }


            }
            return n_decides;
        }
        public int count_possible(int val)
        {
           // Console.WriteLine("count_possible****************************************************\n");
            int n = 0;
            while (val != 0) //TODO:
            {
                n += val & 1;
                val >>= 1;
            }
            return n;
        }
        public bool valid()
        {
            Console.WriteLine("valid****************************************************\n");
            for (int i = 0; i < SIDES * N; i++)
            {
                if (my_clues[i] == 0) continue;

                bool is_decided = true;
                for (int j = s[i], k = 0; k < N; j += inc[i], k++)
                {
                    if (count_possible(possible[j]) != 1)
                    {
                        is_decided = false;
                        break;
                    }
                }

                if (is_decided)
                {
                    int largest = 0, n_clue = 0;
                    for (int j = s[i], k = 0; k < N; j += inc[i], k++)
                    {
                        if (largest < possible[j])
                        {
                            n_clue++;
                            largest = possible[j];
                        }
                    }
                    if (n_clue != my_clues[i]) return false;
                }
            }

            return true;
        }
        public void write_results()
        {
            Console.WriteLine("write_results****************************************************\n");
            for (int i = 0; i < N * N; i++)
            {
                int x = i / N, y = i % N;
                for (int j = 0; j < N; j++)
                {
                    if ((1 << j) == possible[i])
                    {
                        results[x, y] = j + 1;
                        break;
                    }
                }
            }
        }
        public bool dfs(int idx)
        {
            Console.WriteLine("dfs****************************************************\n");
            // printf("%d %d\n", idx, order[idx]);
            if (idx >= order.Count) //TODO:
            {
                if (valid())
                {
                    write_results();
                    return true;
                }
                return false;
            }

            int i = order[idx];
            int[] possible_bak = new int[N * N];

            Array.Copy(possible, possible_bak, N * N);//TODO: ТУТ!!!!(поменял местами possible и possible_back)
            //memcpy(possible_bak, possible, sizeof(int) * N * N);

            for (int j = 0; j < N; j++)
            {
                int m = (1 << j) & possible[i];
                if (m == 0) continue;

                set_value(i, j);
                bool found = false;
                if (valid())
                {
                    found = dfs(idx + 1);
                }
                if (found)
                {
                    return true;
                }
                Array.Copy(possible_bak, possible, N * N); //TODO:(поменял местами possible и possible_back)
                //memcpy(possible, possible_bak, sizeof(int) * N * N);
            }
            return false;
        }
        public List<List<int>> solvePuzzle(List<int> clues)
        {
            Console.WriteLine("SolvePuzle****************************************************\n");
            my_clues = clues;
            for (int i = 0; i < N * N; i++) possible[i] = MASK;

            for (int i = 0; i < N; i++)
            {
                s[i] = i;
                e[i] = (N - 1) * N + i;
                inc[i] = N;
            }

            for (int i = 0, j = N; i < N; i++, j++)
            {
                s[j] = i * N + N - 1;
                e[j] = i * N;
                inc[j] = -1;
            }

            for (int i = 0, j = 2 * N; i < N; i++, j++)
            {
                s[j] = N * N - 1 - i;
                e[j] = N - 1 - i;
                inc[j] = -N;
            }

            for (int i = 0, j = 3 * N; i < N; i++, j++)
            {
                s[j] = (N - i - 1) * N;
                e[j] = (N - i) * N - 1;
                inc[j] = 1;
            }

            for (int i = 0; i < SIDES * N; i++)
            {
                // int i = 12;
                if (my_clues[i] == 0) continue;
                for (int j = s[i], k = 0; k < N; j += inc[i], k++)
                {
                    int m = MASK;
                    for (int l = N + k - my_clues[i] + 1; l < N; l++) m ^= 1 << l;
                    possible[j] &= m;
                }
                
                Console.WriteLine($"i = {i} my_clues[i] = {my_clues[i]}");

                print_possible();
            }

            Console.WriteLine("****************************************************\n\n\n\n");

            while (check_unique() > 0) Console.WriteLine("check_unique****************************************************"); 

            List<KeyValuePair<int, int>> idx_npos = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < N * N; i++)
            {
                
                int n_possible = count_possible(possible[i]);
                if (n_possible > 1)
                {
                    idx_npos.Add(new KeyValuePair<int, int>(n_possible, i));
                }
                Console.WriteLine("count_possible****************************************************\n");
                print_possible();
            }

            // idx_npos.Sort();



            idx_npos.Sort((a, b) =>
            {
                int comp = a.Key.CompareTo(b.Key);
                return comp != 0 ? comp : (a.Value.CompareTo(b.Value));
            });
            //sort(idx_npos.begin(), idx_npos.end());


            order.Clear();
            for (int i = 0; i < idx_npos.Count; i++)
            {
                order.Add(idx_npos[i].Value);
            }
            dfs(0);

            List<List<int>> r = new List<List<int>>();   //TODO: Вот тута ниже ошибка ошибка заполняется 0
            for (int i = 0; i < N; i++)
            {
                List<int> vec = new List<int>();
                {
                    for (int j = 0; j < N; j++) vec.Add(results[i, j]);
                    r.Add(vec);
                }

            }
            Console.WriteLine("print_possible prefer rerurn****************************************************");
            print_possible();
            return r;
        }

        public void print_binary(int x)
        {
            for (int i = N - 1; i >= 0; i--)
                Console.Write((x & (1 << i)) != 0 ? 1 : 0); //TODO:
        }

        public void print_possible()
        {
            Console.WriteLine("print_possible: \n");
            for (int i = 0; i < N * N; i++)
            {
                print_binary(possible[i]);
                Console.Write(" ");
                if (i % N == N - 1) Console.Write("\n");
            }
            Console.WriteLine("\n");
        }
    }
}

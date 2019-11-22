document.addEventListener("DOMContentLoaded", function() {
    var element = document.createElement("p");
    element.textContent = "Thsi is the element from third.js file";
    document.querySelector("body").appendChild(element);
});
// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function() {
    var extraButtons = document.getElementById('extraButtons');
    extraButtons.style.display = 'none'; // Ensure the initial display style is set

    document.getElementById('more-button').addEventListener('click', function() {
        if (extraButtons.style.display === 'none' || extraButtons.style.display === '') {
            extraButtons.style.display = 'flex';
        } else {
            extraButtons.style.display = 'none';
        }
    });
});
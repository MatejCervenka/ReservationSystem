﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function() {
    var buttonContainers = document.getElementsByClassName('button-container');

    for (var i = 0; i < buttonContainers.length; i++) {
        (function(container, index) {
            var moreButton = container.getElementsByClassName('more-button')[0];
            var extraButtons = container.getElementsByClassName('extra-buttons')[0];

            if (moreButton && extraButtons) {
                console.log('Initializing button container:', index);
                extraButtons.style.display = 'none';

                moreButton.addEventListener('click', function() {
                    if (extraButtons.style.display === 'none' || extraButtons.style.display === '') {
                        extraButtons.style.display = 'flex';
                    } else {
                        extraButtons.style.display = 'none';
                    }
                });
            } else {
                console.error('Missing more button or extra buttons in container at index:', index);
                console.error('Container HTML:', container.innerHTML);
            }
        })(buttonContainers[i], i);
    }

    // Inicializace mapy
    var map = L.map('map').setView([51.505, -0.09], 13);

    // Přidání mapových podkladů z OpenStreetMap
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    // Přidání markeru na mapu
    L.marker([51.5, -0.09]).addTo(map)
        .bindPopup('Ahoj! Jsem zde.')
        .openPopup();
});


/** @type {import('tailwindcss').Config} */
const colors = require("tailwindcss/colors");
const defaultTheme = require('tailwindcss/defaultTheme')

delete colors[`lightBlue`];
delete colors[`warmGray`];
delete colors[`trueGray`];
delete colors[`coolGray`];
delete colors[`blueGray`];


module.exports = {
    darkMode: 'class',
    content: [
        "./**/*.{razor,cs}"
    ],
    plugins: [
        require('@tailwindcss/forms'),
        require('@tailwindcss/typography'),
        require('@tailwindcss/aspect-ratio')
    ],
    theme: {
        extend: {
            fontFamily: {
                sans: ['InterVariable', ...defaultTheme.fontFamily.sans],
            },
            borderRadius: {
                'xs': '0.0625rem',
            },
            colors: {
                brand: {
                    '50': '#eff9ff',
                    '100': '#dff1ff',
                    '200': '#b7e5ff',
                    '300': '#77d1ff',
                    '400': '#2fbbff',
                    '500': '#04a3f3',
                    '600': '#0081d0',
                    '700': '#0067a8',
                    '800': '#015486',
                    '900': '#074873',
                    '950': '#052e4c',
                },
            }
        },
    },
};

#!/bin/bash
# file: css.sh
source ~/.zshrc
nvm use
npm install tailwindcss@next @tailwindcss/vite@next
npx @tailwindcss/cli@next -i src/Pure.Blazor.Components/tailwind.css -o src/Pure.Blazor.Components/wwwroot/pureblazor.css --watch
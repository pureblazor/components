#!/bin/bash
# file: css.sh
source ~/.zshrc
nvm use
npm install tailwindcss@next @tailwindcss/vite@next
npx @tailwindcss/cli@next -i PureBlazor.com/tailwind.css -o PureBlazor.com/wwwroot/site.css --watch
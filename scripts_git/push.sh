#!/bin/bash

git checkout -b "$(whoami)-branch"
git checkout "$(whoami)-branch"
git add .
read -p "commit message : " message
git commit -am "$message"
git push origin "$(whoami)-branch"

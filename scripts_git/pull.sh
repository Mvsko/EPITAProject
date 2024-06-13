#!/bin/bash

# commit to current branch before pull
git checkout -b "$(whoami)-branch"
git checkout "$(whoami)-branch"
git add .
read -p "commit message : " message
git commit -am "$message"


#pull
git checkout main
git pull origin main
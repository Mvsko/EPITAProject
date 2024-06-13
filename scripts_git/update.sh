#!/bin/bash

git fetch origin
git branch -d backup-master
git branch backup-master
git reset --hard origin/main
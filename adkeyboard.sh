#!/usr/bin/env bash

set -e

exit_code=0

while [ $exit_code == 0 ]; do
  echo -n "Input: "
  read input
  echo -n "Sending..."
  adb shell input text "$input"
  exit_code=$?
  if [ $? == 0 ]; then
    echo -e " Success!"
  fi
done

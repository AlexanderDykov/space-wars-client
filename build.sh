#!/usr/bin/env sh

set -x

export UNITY_EXECUTABLE=${UNITY_EXECUTABLE:-"/Applications/Unity/Unity.app/Contents/MacOS/Unity"}
# export BUILD_NAME=${BUILD_NAME:-"ExampleProjectName"}
export BUILD_NAME="SpaceWars"

BUILD_TARGET=WebGL ./.github/actions/buildProject/build.sh
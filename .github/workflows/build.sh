#!/bin/bash

UNITY_PATH="/opt/Unity/Editor/Unity"  # Path to Unity executable on the CI runner

# Run tests with Unity CLI
$UNITY_PATH -batchmode -quit -projectPath $(pwd) -runTests -testPlatform editmode -testResults ./test-results.xml -logFile

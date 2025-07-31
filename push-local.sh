#!/bin/bash

dotnet build src
dotnet nuget push **\*.nupkg --source $HOME/code/nuget

#!/bin/bash
set -ex

if [ -d "/publish" ];
then
    if [ "$TARGETPLATFORM" = "linux/amd64" ];
    then
        cp -rf /publish/amd64/* /wuji
    elif [ "$TARGETPLATFORM" = "linux/arm64" ];
    then
    cp -rf /publish/arm64/* /wuji
    elif [ "$TARGETPLATFORM" = "linux/arm/v7" ];
        then cp -rf /publish/arm/* /wuji
    else
        echo "架构错误"
    fi
    rm -rf /publish
else
    echo "目录不存在"
fi
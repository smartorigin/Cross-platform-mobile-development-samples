#!/bin/sh
echo ""
echo "Cleaning up"  #optional..
rm -rf libs

echo ""
echo "Compiling NativeCode.c..."
/Applications/android-ndk-r16/ndk-build NDK_PROJECT_PATH=. NDK_APPLICATION_MK=Application.mk $*

echo ""
echo "removing build folders"  #optional..
rm -rf obj

echo ""
echo "Done!"

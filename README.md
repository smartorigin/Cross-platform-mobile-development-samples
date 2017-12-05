# Cross-platform mobile development samples

This projects presents different samples for cross-platform mobile devlopment.

With goal to run native code in a crossplatform mobile development context.

By native code we say using managed code like a C/C++ module.

## Getting started 

Clone this repo recursively (--recursive) then refer to the README file associated to the project you want to test.

***NB** --recursive needed for React-Native*

## Folder structure

    Cross-plateform mobile devlopment samples 
    |-- C
    |-- doc
    |-- React-Native
    |-- Unity
    |-- Xamarin

**C** → A simple lib that expose 'sum' method, a sample of the kind of code we would like to run.

**doc** → Contains a `.pdf` presentation that explain the experience behind this repo.

**React-Native** → A sample React Native project with a try to use native module

**Unity** → An Unity project that could run both on Android / iOS / Desktop (with a call to native code)

**Xamarin** → Sample project that run on both iOS and Android calling a native library.

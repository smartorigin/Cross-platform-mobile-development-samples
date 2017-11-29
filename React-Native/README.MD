#React Native

Based on  : https://github.com/MathieuDebit/Djinnius
Which use : https://github.com/dropbox/djinni

/!\ Native code binding to android not done

Here's another sample code worth reading : https://github.com/boloutaredoubeni/Twenty48

## Get started

1. Follow the step [here](https://facebook.github.io/react-native/docs/getting-started.html)

2. Run the following commands (in Djinnius-master) :

       yarn install
       make ios

2. Launch 
 
       react-native run-android

       or

       react-native run-ios

#### Troubleshooting android

1. If you have the following error :

        `You have not accepted the license agreements of the 
        following SDK components:...`

    Create a simple project via `Android Studio` targeting the needed SDK then run it, `Android Studio` will prompt you to accept licence

2. If you have the following error :

       A problem occurred configuring project ':app'. > SDK location not found. Define location
    
    Run the following command : 
       
         export ANDROID_HOME=/Users/{USERNAME}/Library/Android/sdk
         
3. If you have the following line be fore launching the app : 

        /bin/sh: adb: command not found

    Run the following command : 

         export PATH=${PATH}:${ANDROID_HOME}/tools:${ANDROID_HOME}/platform-tools

4. /!\ Makefile references 

        /Applications/android-ndk-r16/ for ANDROID_BUILD_TOP

5. In case of `Could not get BatchedBridge, make sure your bundle is packaged properly`

Run the following command : 
     
        adb reverse tcp:8081 tcp:8081

#### Troobleshooting iOS

1. If you have the following error :

        xcrun: error: unable to find utility "instruments", not a developer tool or in PATH

    Follow these [instructions](https://stackoverflow.com/a/39779171/5102373)

## Help

http://blog.tylerbuchea.com/how-to-create-a-react-native-ios-native-module/
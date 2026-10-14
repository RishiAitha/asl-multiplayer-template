# Sign Language Multiplayer Template

This is a template project outlining how to set up basic systems for social games involving sign recognition for sign language learning.

## Setting up Unity's Multiplayer Services SDK

Much of the relevant info for creating multiplayer systems can be found here: [Multiplayer Services SDK Docs](https://docs.unity.com/en-us/mps-sdk)

There are very many approaches to setting up multiplayer games with Unity or other engines. The examples here use a particular approach that is easy to test but still functional when deployed; we use Netcode for GameObjects for basic object networking, send information over a Relay network, and handle match creation with Matchmaker. This allows us to skip cumbersome join codes and other systems. However, feel free to utilize your own alternative approaches! This is not the ONLY way to make a multiplayer mobile game.

Below is very detailed guidance on setting up a project from scratch. When cloning this template, similar steps can be followed, although some has already been done for you.

When creating a project in Unity Hub (ensure you are signed in already), there are two options. You can create a cloud project, or create it locally. By choosing the cloud option, your project will be automatically linked to a Unity Cloud project on your account. You can see it at [Unity Cloud](https://cloud.unity.com/).
![Unity Hub Project Creation](/img/project-creation-hub.png)
![Unity Cloud Project Page](/img/unity-cloud-project-page.png)

If the project isn't linked correctly, or you haven't created a cloud project, you can go into Services under Project Settings and link the project manually. After selecting your organizatio, you'll get to choose between making a new project, or linking to an existing one (set it up on the cloud website if needed).
![Services Settings Page](/img/services-settings.png)

Once the project setup is done, you'll need to install the Multiplayer Services SDK package. It can be found in the unity registry in the package manager, and has the name "com.unity.services.multiplayer".
![Multiplayer Services Package](/img/multiplayer-services-package.png)

Another useful package is the Multiplayer Play Mode package, which allows you to open multiple instances of the project to test multiplayer features without building to multiple devices. The name is "com.unity.multiplayer.playmode".
![Multiplayer Play Mode Package](/img/multiplayer-play-mode-package.png)

For setting up Matchmaker, we need to take a few additional steps.
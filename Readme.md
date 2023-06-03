# AI Web application built with Svelte and C# WebApi

A simple web app using OpenAI Apis to edit and create images based on your instructions.

For example, you can use the Text Editor app to fix grammar, and spelling mistakes, translate and more.

Using the image creator app, you can generate your desired image(s) using the prompt box. Also, you can customize the sizes and number of images.

# Demo

[![Demo](/demo/demo.mp4)

## Folders

-   openai folder contains a scaffolded Svelte-kit app.

-   Sajan.OpenAi contains a scaffolded dotnet webapi rest service app.

## How to run the Svelte frontend app

`cd openai && npm install` and create a .env file it contain 2 key that holds the backend endpoint.

```bash

TEXT_EDITOR_ENDPOINT=http://localhost:5069/api/AITextEditor

IMAGE_CREATOR_ENDPOINT=http://localhost:5069/api/AIImage

```

After that just run `npm run dev --open` this will fire up your browser with the listning port [localhost](http://localhost:3001)

## How to run the C# webapi backend app

`cd Sajan.OpenAi && dotnet restore` and open the`appsettings.json` file add your OpenAi API token in the "Token" field. Create your OpenAI API token here [Generate your token](https://platform.openai.com/account/api-keys)

```json

"OpenAIRemoteService": {

"Url":  "https://api.openai.com/v1",

"Token":  ""

},

```

After that just run `dotnet run` this will open a browser with swagger UI where you can play around with the Open AI API endpoint and see the schema details for this application.

Note: The code in the repo is for education and local development purposes only. However, you can use it in whatever way you want. I am not responsible for any kind of issues.

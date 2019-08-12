# redington-tech-test

Redington Mini Project Tech Test

## TLDR

------

I decided to go for a web api backend and a SPA front end.

You can find the client app here => [App](https://aw-probability-calculator.azurewebsites.net/)  

You can find the swagger for the backend here => [Swagger](https://aw-redington.azurewebsites.net/swagger/index.html)  


## Why did I do this?

---------

I chose this solution in order to demonstrate a range of front and back end skills.

In a real world situation this is probably a bit over-engineered for the task given. In a non test situation, where there were other factors to consider such as time constraints etc., I would have considered a simpler solution such as a simple WPF desktop app or a basic MVC site.

A RESTful API allows me to deliver what ever client might be required without having to repeat any of the calculation and logging work.

I went for a React.js client because I have been wanting to try it out for a while and thought this would be a great opportunity. If I had a bit more time I would have investigated:

- Using Typescript.
- A library for doing the forms with validation. The way I went for is fine but I am sure there is a more elegant solution out there.
- Deploying to Azure without having to commit the build folder to source control.
- Per environment config

## How to run this locally

---------

1. Download or clone the repo.
2. Go to the `\API\RedingtonTechTest.WebAPI` folder in a terminal and use the command `dotnet run`.
3. This will start a site on http://localhost:5000.
4. You can go to http://localhost:5000/swagger to explore the API.
4. In the `\Client\redington-tech-test-client\src\app-config.js` file uncomment the path to the locally running API. You can also just leave this and point at the DEV environment if you prefer.
5. Use the command `npm start` and the client app will now be hosted on http://localhost:3000.
6. The log file can be found in the `API\RedingtonTechTest.WebAPI\logs\` folder. 

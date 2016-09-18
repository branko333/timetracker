# TimeTracker

This is a sample application and research project for ASP.NET Core, Aurelia and other libraries, frameworks and tools:

- ASP.NET Core / WebAPI
- Aurelia
- Aurelia CLI
- Entity Framework Core (for now, Marten later)
- ASP.NET Identity Framework Core
- IdentityServer4
- ASP.NET MVC Boilerplate
- MediatR
- ...

A lot of things are in the flux, including the content of this readme file.

## Functionality

TimeTracker is a simple application for collecting daily timesheet entries for a (freelance) developer.

### Requirements

The application collects daily `Timesheet` from `Developer`, for a particular `Employer`, employer's `Client` and client's `Project`. Each timesheet entry also contains description, date, hours spent and hourly wage / rate.

Developer hourly rate is definable per employer, client and project where each subsequnt rate overrides previous one.

Developer has the ability to display timesheet summaries filtered per period, employer, client and project.

`Employer manager` has the ability to display timesheet summaries filtered per developer, period, client and project. Manager can also create clients and projects, set developer's hourly rate and assign her to various projects.

`Admin` can create employers, assign managers and developers to employers, view system log, etc.

## Application setup

TODO

### Server side setup

TODO

### Client side setup

1. Ensure that [NodeJS](https://nodejs.org/en/) is installed. This provides the platform on which the client side build tooling runs. It's most likely installed with Visual Studio 2015+ (optional install).

2. From the project folder, execute the following command:

    ``` shell
    npm install
    ```

3. Ensure that [Gulp](http://gulpjs.com/) is installed. If you need to install it, use the following command (will be installed globally):

    ```shell
    npm install -g gulp
    ```

4. Ensure that [Jspm](http://jspm.io/) is installed. If you need to install it, use the following command (will be installed globally):

    ```shell
    npm install -g jspm
    ```

5. Install all JSPM dependencies

    ```shell
    jspm install
    ```

6. To build the client side code, you can now run:

    ```shell
    gulp build
    ```

> From Aurelia readme - Note: jspm, like Bower and Yeoman, leverages git so you need to install that if you don't have it. Also, jspm queries GitHub to install packages, but GitHub has a rate limit on anonymous API requests. It is advised that you configure jspm with your GitHub credentials in order to avoid problems. You can do this by executing `jspm registry config github` and following the prompts. If you choose to authorize jspm by an access token instead of giving your password (see `GitHub Settings > Personal Access Tokens`), `public_repo` access for the token is required.

## Contribution guidelines ##

TODO...

* Writing tests
* Code review
* Other guidelines

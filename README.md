# **OWASP_Insecure_Design**
This Repository contains a demo application regarding the OWASP Top 10 security categories. The main focus of this project regards the category: A04:2021 - Insecure Design

# Table of Contents
- [What is OWASP Top 10?](#what-is-owasp-top-10)
- [Szenario](#szenario-smart-home-visualization)
- [Objective](#objective)
- [Project Structure](#project-structure)

# What is OWASP Top 10?
OWASP Top 10 refers to a list of the ten most critical web application security risks identified by the Open Web Application Security Project (OWASP). The list is updated every few years to reflect the current state of web application security threats.

The OWASP Top 10 list provides guidance to developers, testers, and security professionals to help them understand the most common and dangerous vulnerabilities that exist in web applications. It is widely used as a benchmark for security testing and as a starting point for securing web applications.

The current version of the OWASP Top 10, released in 2021, includes the following vulnerabilities:

- **A01:2021** - Broken Access Control
- **A02:2021** - Cryptographic Failures
- **A03:2021** - Injection
- **A04:2021** - Insecure Design
- **A05:2021** - Security Misconfiguration
- **A06:2021** - Vulnerable and Outdated Components
- **A07:2021** - Identification and Authentication Failures
- **A08:2021** - Software and Data Integrity Failures 
- **A09:2021** - Security Logging and Monitoring Failures
- **A10:2021** - Server-Side Request Forgery

It is important for developers, security professionals, and organizations to be aware of these vulnerabilities and take steps to mitigate them in their web applications. By addressing these vulnerabilities, organizations can better protect themselves and their users from the risks of cyberattacks and data breaches.

For further information about OWASP please click [here](https://owasp.org/Top10/).

## Insecure Design Description
Insecure design is a broad category representing different weaknesses, expressed as “missing or ineffective control design.” Insecure design is not the source for all other Top 10 risk categories. There is a difference between insecure design and insecure implementation. We differentiate between design flaws and implementation defects for a reason, they have different root causes and remediation. A secure design can still have implementation defects leading to vulnerabilities that may be exploited. An insecure design cannot be fixed by a perfect implementation as by definition, needed security controls were never created to defend against specific attacks. One of the factors that contribute to insecure design is the lack of business risk profiling inherent in the software or system being developed, and thus the failure to determine what level of security design is required.[^insecure_design]

[^insecure_design]: [OWASP Top 10: Insecure Design](https://owasp.org/Top10/A04_2021-Insecure_Design/)

# Szenario: Smart-Home Visualization
- Login with username and password
- A visualization screen in which functions of a smart home can be controlled
    - for all users
    - at least 3 Sensors (value display, e.g. actual temperature, status, etc)
    - at least 3 Actuators (value display, e.g. actual temperature, status, etc)
- A configuartion screen
    - different for "normal" and "admin" users
    - e.g. label for sensors/actuators, Interface Config Mockup, etc. for admins
    - e.g. name and user profile, etc. for "normal" users
- A history / log screen
    - log / listing of revelant activities (e.g. configuration changes, settings, etc.)
- Assumption: visualization uses a backend for the actual control (e.g. via CLI/ rest-API/etc.)

# Objective
Create a demo application to demonstrate the chosen vulnerability. As described earlier, this specific project focuses on the category [***A04:2021 - Insecure Design***](#insecure-design-description).

In general here are some tips to avoid this critical security risk[^insecure_design]: 
- Establish and use a secure development lifecycle with AppSec professionals to help evaluate and design security and privacy-related controls
- Establish and use a library of secure design patterns or paved road ready to use components
- Use threat modeling for critical authentication, access control, business logic, and key flows
- Integrate security language and controls into user stories
- Integrate plausibility checks at each tier of your application (from frontend to backend)
- Write unit and integration tests to validate that all critical flows are resistant to the threat model. Compile use-cases and misuse-cases for each tier of your application.
- Segregate tier layers on the system and network layers depending on the exposure and protection needs
- Segregate tenants robustly by design throughout all tiers
- Limit resource consumption by user or service

# Project Structure
As most applications, this project is split into three different sections:
- **Backend** (C#)
- **Database** (MySQL)
- **Frontend** (Angular / React Framework)

## Prepairing the Backend
### **Prerequisites**
- Visual Studio or Visual Studio Code with the C# extension
- The preferred .NET SDK (In this case 7.0)

### **Creating the Application with VS Code**
1. Open VS Code
2. Go to the Folder where your project should be created
3. Create the project for the application:
    ```
    dotnet new console -o NAMEOFPROJECT
    ```
4. Create the class library for the application:
    ```
    dotnet new mstest -o NAMEOFTHECLASSLIBRARY
    ```
5. Create a Solution File:
    ```
    dotnet new sln
    ```
6. Add the projects to the solution:
    ```
    dotnet sln add NAMEOFPROJECT
    dotnet sln add NAMEOFTHECLASSLIBRARY
    ```
7. Add a reference so that the project can use the classlibrary:
    ```
    dotnet add NAMEOFPROJECT reference NAMEOFTHECLASSLIBRARY
    ```

### **How to run the application**
To run the application, go to the the application project and use the command:
```
dotnet run
```


## Prepairing the Frontend
### **Prerequisites**
- Visual Studio Code with the *Angular* extension
- Install Angular with the cmd prompt: `npm install -g @angular/cli`

### **Initialize the Angular Project in VS Vode**
1. Open VS Code
2. Go to the Folder where your frontend project should be created
3. Create the angular project:
    ```
    ng new
    ```

    There will be questions to initialize the preferred angular project:
    
    a. What name would you like to use for the new workspace and initial project?
    ```
        NAMEOFPROJECT
    ```
    b. Would you like to add Angular routing?
    ```
        Yes <--
        No
    ```
    c. Which stylesheet format would you like to use?
    ```
        CSS <--
        SCSS
        SASS
        LESS
    ```
4. Add Angular Material:

    First go to the created angular project and add ***Angular Material***:
    ```
    ng add @angular/material
    ```

    There will be questions to initialize the preferred material style:
    
    a. Choose a prebuilt theme name, or "custom" for a custom theme:
    ```
        Indigo / Pink <--
        Deep Purple / Amber
        Pink / Blue Grey
        Purple / Green
    ```
    b. Set up global Angular Material typography styles?
    ```
        Yes <--
        No
    ```
    c. Include the Angular animations module?
    ```
        Include and enable animations <--
        Include, but disable animations
        Do not include
    ```

### **How to run the frontend**
To run the  frontend application, go to the the frontend project and use the command:
```
ng serve
```

# Execution
<p>
  <a href="./backend">
    <img src="https://img.shields.io/badge/Go%20to-Backend-000"/>
  </a>
</p>
<p>
  <a href="./frontend/owasp-top10/">
    <img src="https://img.shields.io/badge/Go%20to-Frontend-fff"/>
  </a>
</p>
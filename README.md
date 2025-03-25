
# Selenium with C# BDD Framework



## Objective

A behavior-driven development framework in Selenium allows you to complete testing in plain English from specification and business requirements
with support for parallelization and the extent report.
## Approach

- UI testing
- Functional testing 
- Extent Report


## Packages :

- SpecFlow (BDD) - latest
- Selenium WebDriver - latest
- Selenium (Web Driver Manager) - latest
- NUnit (3.12.2)
- Extent Report (4.1.0)
- .NET (6.0)
## Tools

 - [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/)


## Step to run tests in Visual Studio(Community)

- Clone web-automation in local device
- Open clone project in Visual Studio Community
- Double click on RiskScreen.vlc file
- Right click on Project Solution and build the project
- Open Test Explorer and run the features


## Step to run tests through Command Line

Clone the project

Go to the project directory

```bash
  cd web-automation
```

Install dependencies/packages

```bash
  dotnet build
```

Run the test

```bash
  dotnet test
```


## Folder Structure
- Features - Used to Write Feature file.
- Report - Used to store Reports and Screeshots.
- Resources/ - Page Object Model, used to specify an element's string format and action of function.
- Drivers/Drivers.cs - Simply create the object of the driver classes and work with them. It helps you to execute Selenium Scripts on desired browser. (Don't edit)
- Drivers/Hook.cs - This file allows us to manage the code workflow better and helps to reduce code redundancy.(Don't edit)
- StepDefinitions/ - Step definition maps the Test Case Steps in the feature files(introduced by Given/When/Then) to code.
- Utility/Asserts - Asserts are validations or checkpoints for an application.
- Utility/Common - This folder contain reusable method's like click, hover, sendkey and etc (if needed to add new method we can).
- Utility/FrameworkConstant - The folder is integration of the c# classes that store the static variables referencing to the paths.(Don't edit)
- Utility/GetElement - GetElement method in Framework, which helps you identify a web element.(Don't edit)
- Utility/ReadAppSettings - The data present in the properties file is stored as Key-Value pairs, so we can access any data in this file by using the key.
- Utility/Waits - help to observe and troubleshoot issues that may occur due to variation in time lag. 
- appsetting.json -  Data is stored in application.json file in the form of key-value pairs, Which is used to set driver,runmode and etc. Also we add more data according to key value pair.



## Running Tests

To run tests, run the following command
```bash
  dotnet test
```
You can always see the Reports folder in the format of  HtmlReport_04_01_2023_19_07_55.html

## Report

![image](https://github.com/user-attachments/assets/dd54167f-cb5f-47bb-9694-9874eaf3248c)

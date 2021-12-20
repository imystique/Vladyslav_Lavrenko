# Vladyslav_Lavrenko

☃️ #DoNotChangeCredentials ☃️

To begin work with this document, you need to install next NuGet Packages:

1. Microsoft.NET.Test.Sdk
2. NUnit.
3. NUnit3TestAdapter.
4. SpecFlow.Plus.LivingDocPlugin.
5. SpecFlow.
6. SpecFlow.NUnit.
7. Selenium.WebDriver.
8. Selenium.Support.
Also, to use WebDriver, you need to download ChromeWebDriver for your Chrome Browser using this link https://chromedriver.chromium.org/downloads. Then you should create a folder: "C:\WebDriver" and put there chromedriver.exe (if you use Windows).

To make reports, you need to use SpecFlow.Plus.LivingDocPlugin, but before you need to install SpecFlow.Plus.LivingDoc.CLI using this command in PowerShell: "dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI". Next, to create .html file, use command: "livingdoc test-assembly C:\Users\freez\source\repos\ClassLibrary5\ClassLibrary5\bin\Debug\ClassLibrary5.dll". Next you need to run tests and after that you should write next command: "livingdoc test-assembly C:\Users\freez\source\repos\ClassLibrary5\ClassLibrary5\bin\Debug\ClassLibrary5.dll -t C:\Users\freez\source\repos\ClassLibrary5\ClassLibrary5\bin\Debug\TestExecution.json". After that you can open .html file and see the results.

If you want to execute tests, you have 4 ways:

1. "Run All Tests In View" in Microsoft Visual Studio to run all tests.
2. "Run Test" in Microsoft Visual Studio to run one test which you want.
3. Open Developer PowerShell and use command "dotnet test" to run all tests.
4. Open Developer PowerShell and use command "dotnet test -filter TestName" to run one test which you want.
5. Open Command Line and use command "dotnet test ..\YourPath\File.sln" to run all tests.
6. Open Command Line and use command "dotnet test --filter TestName ..\YourPath\File.sln" to run one test which you want.

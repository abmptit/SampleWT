# SampleWT
This solution is used to reproduce some selenium bugs.
This solution is composed by 
- SeleniumClient : contains helpers to better use the OpenQA.Selenium Api
- SeleniumServer : contains chrome driver file (maybe later a standalone server)
- TestedSite : contains sample html/js page to reproduce specific tested cases.
- AppConfig : contains app config which include SeleniumServerConfig/ SeleniumClientConfig
- Nunit Tests : contains some tests to reproduce the known bugs. 

Prerequesite : Install the Nunit 3 Test Adapter and enable it: 
On VS, click tools "Extensions and updates" search online for Nunit 3 Test Adapter, install it and enable it.

## FrameTestFixture to test Frame behavior
We noticed that some click is not working when we used a page with an IFrame.
We create a sample tested page into TestedSite to reproduce this specific tested cases.




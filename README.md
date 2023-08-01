# Qase.io

This solution tests GUI and API of Qase.io website.

## Test suites

#### GUI:

#### 1. Projects
- Creating
- Deleting
- Updating
#### 2. Test Suites
- Creating
- Deleting
#### 3. Test Cases
- Creating
- Deleting one case
- Deleting several cases

#### API:

#### 1. Test Suites
- Creating
- Deleting
- Updating

#### 2. Defect
- Creating
- Deleting
- Updating

## Used technologies

- **Bogus** by bchavez
- **NLog** by Jarek Kowalski,Kim Christensen,Julian Verdurmen
- **NUnit.Allure** by Nick Chursin
- **RestSharp** by .NET Foundation and Contributors
- **System.Text.Json** by Microsoft
- **File Patch Build and Release Tasks** by Geek Learning
- **Allure Report Viewer** by Michael Clay

## Used test development approaches

- Driver Factory
- Browser
- Page Object
- PageSteps
- Wrappers
- Builder for model
- Chain of invocation
- Bogus

## Installation
- In Visual studio: File -> Clone repository.
Insert url of this project and select solution directory.
- Install [Allure](https://docs.qameta.io/allure/).
- Register on [qase.io](https://qase.io/). Get your user login, password and [API token](https://help.qase.io/en/articles/6664970-api-tokens).
- Insert your login, password and API token into appdata.json.
- Clean and build Solution.

## Allure reporting
in directory .\Tests\bin\Debug\net6.0

run script

```allure serve```

# SauceDemo Selenium Framework

## Overview
Automation framework for https://www.saucedemo.com using:
- Selenium WebDriver
- NUnit
- Page Object Model
- Data Driven Testing
- Parallel Execution
- Chrome & Edge support

---

## Test Cases

- UC-1: Empty credentials -> "Username is required"
- UC-2: Only username -> "Password is required"
- UC-3: Valid login -> validate:
  - Burger menu button
  - "Swag Labs" label
  - Shopping cart icon
  - Sorting dropdown
  - Inventory items list

---

## Browsers Supported
- Chrome
- Edge

---

## Testing Approach
- CSS selectors for all locators
- Data-driven testing using TestCaseSource
- Parallel execution enabled
- FluentAssertions for validations
- Page Object Model design pattern

---

## Run Tests
```bash
dotnet test
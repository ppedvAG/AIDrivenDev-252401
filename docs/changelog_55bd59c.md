# Changelog: Commit 55bd59c

**Commit Message:** `tests für domain`
**Author:** Arjan Verma
**Date:** Thu Dec 18 14:04:07 2025 +0100
**Parent Commit:** `f2e4c2e`

## Overview

This commit introduces unit tests for the Domain layer and significantly updates the project documentation. The primary focus was to ensure the reliability of the core business logic entities and provide clear instructions for the project.

## Changes

### 1. New Test Project: `MiniShop.Domain.Tests`

A new xUnit test project was created to test the `MiniShop.Domain` project.

- **Project File**: `tests/MiniShop.Domain.Tests/MiniShop.Domain.Tests.csproj`
    - Added reference to `MiniShop.Domain`.
    - Configured for .NET 9.0.
    - Included `xunit` and `xunit.runner.visualstudio` dependencies.

- **New Test Classes**:
    - **`CartTests.cs`**:
        - Tests `Cart.AddItem` for adding new items.
        - Tests `Cart.AddItem` for increasing quantity of existing items.
        - Tests validation logic (e.g., invalid quantities).
    - **`CartItemTests.cs`**:
        - Tests `CartItem` constructor validation.
        - Tests `CartItem.Increase` method.
    - **`ProductTests.cs`**:
        - Tests `Product` constructor and property assignments.
        - Tests default constructor behavior.
    - **`PriceTests.cs`**:
        - Tests `Price` value object creation and properties.

### 2. Solution Update

- **`MiniShop.sln`**:
    - Added the `MiniShop.Domain.Tests` project to the solution configuration.

### 3. Documentation

- **`README.md`**:
    - Completely rewritten to provide a comprehensive project overview.
    - Added sections for:
        - **Project Structure**: Explaining Domain, Application, Infrastructure, and App layers.
        - **Features**: Highlighting DDD, AI integration, and Testing.
        - **Prerequisites**: Listing .NET 9.0 and OpenAI API Key requirements.
        - **Getting Started**: Step-by-step guide for cloning, configuration, and running the app.
        - **Usage Example**: Describing the console application flow.

## Summary of Statistics

- **Files Changed**: 7
- **Insertions**: 313
- **Deletions**: 2

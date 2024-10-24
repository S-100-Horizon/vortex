# vortex
S-100: An Unexpected Journey

## Project Structure

The [project structure](https://binarybytez.com/understanding-clean-architecture/) is designed to promote separation of concerns and modularity, making it easier to understand, test, and maintain the application.

```
├── src
│   ├── Application             # Contains all kind of applications and plugins
│   ├── Core                    # Contains the core business logic, domain models, view models, etc.
│   ├── Infrastructure          # Contains infrastructure concerns such as data access, external services, etc.
│   └── UI                      # Contains the user interface layer, including controllers, views, extensions, etc.
├── tests
│   ├── Core.Tests              # Contains unit tests for the core layer
│   ├── Infrastructure.Tests    # Contains unit tests for the infrastructure layer
│   └── UI.Tests                # Contains unit tests for the UI layer
└── README.md                   # Project documentation (you are here!)
```

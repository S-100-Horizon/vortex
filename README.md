# Vortex
S-100: An Unexpected Journey

## Project Overview:

The project aimed to implement the S-100 standard within ArcGIS Pro to improve the creation, management, and dissemination of electronic navigational charts (ENCs) in compliance with the International Hydrographic Organization's (IHO) S-100 framework. The implementation of S-100 standards in ArcGIS Pro facilitates the transition from traditional paper charts to modern digital navigational tools, enhancing safety and efficiency in maritime navigation.

## Key Objectives:

1. **Comprehensive Data Management and Validation:**  
The system should support the management of multiple S-100-based product specifications, ensuring that data is validated against the respective feature and portrayal catalogs, while adhering to the S-100 framework’s encoding rules and standards (e.g., S-101, S-125, S-102).

2. **Multi-format Data Export and Interoperability:**  
It should enable the export of data in various formats such as GML, ISO 8211, and HDF5, supporting seamless integration with other geospatial systems. Additionally, the system should include mechanisms for generating and signing data products to ensure data integrity and authenticity.

3. **Flexible Data Editing and Cartographic Tools:**  
The system should provide advanced tools for editing and managing geospatial data, including support for feature editing, geometry validation, and cartographic styling, ensuring compliance with S-100 portrayal rules.

4. **Automated Workflow and Batch Processing:**  
The system should offer automated workflows for routine tasks such as data validation, product generation, and updates. This should include the ability to handle batch processing of large datasets and the production of multiple products simultaneously.

5. **Fully supported S-100 portrayal:**  
Data must be represented in a clearly defined and accurate manner.

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

## Contacts
Jens Søe Christiansen jesoe@gst.dk

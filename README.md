# HugAPet Portal

Welcome to HugAPet - a platform connecting pet shelters, animal lovers, and lost pets. This project aims to provide a central hub for pet shelters to register, publish information about found animals, available adoptions, and donation requirements, while also allowing users to report found animals or animals wandering in specific areas.

## Table of Contents
- [About](#about)
- [Features](#features)
- [Architecture](#architecture)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## About
HugAPet is designed to streamline the process of connecting pet shelters with potential adopters and concerned citizens who encounter lost animals. By centralizing information about found animals, available adoptions, and donation needs, we aim to facilitate faster and more efficient pet rescue and adoption processes.

## Features
- **Shelter Registration:** Pet shelters can register on the platform and publish information about their services.
- **Animal Listings:** Shelters can list information about found animals and animals available for adoption.
- **Donation Requests:** Shelters can specify their requirements for donations such as food, blankets, or medical supplies.
- **User Reporting:** Users can report found animals or animals wandering in specific areas.
- **Search and Filtering:** Users can search for animals based on various criteria such as species, breed, location, etc.
- **User Profiles:** Users can create profiles to save favorite animals, track adoption requests, and manage donations.
- **Notifications:** Users receive notifications about animals matching their preferences or updates from shelters they follow.

## Architecture
The HugAPet application  will follow simplified approach at first.
There will be only one project with vertical slices for specific modules. As feature will be implemented architecture will be changed to reflect specific modules according to their complexity. 


Current state is:
- API Project: HugAPet.API ( Vertical slices + Minimal Api)
- HugAPet.Auth: Auth Server build on top of Identity Server
- HugAPet.UI: Blazor frontend 

## Usage
To run the HugAPet portal locally for development:
1. Clone this repository.
2. Run /infrastructure/init.sh to register certs & hosts
3. Run /infra/docker/docker-compose.yml 
4. Access the application in your browser at `https://ui.local`.


## Contributing
Contributions to the HugAPet project are welcome! If you'd like to contribute, please follow these steps:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/improvement`).
3. Make your changes and commit them (`git commit -am 'Add new feature'`).
4. Push your changes to your forked repository (`git push origin feature/improvement`).
5. Create a new pull request.

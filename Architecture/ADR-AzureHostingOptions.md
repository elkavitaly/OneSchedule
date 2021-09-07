# Selected optimal way to deploy OneSchedule web app and DB into Azure cloud

* Status: proposed
* Deciders: Vitaly Volohovsky, Valeriy Khapilin, Sergiy Skuzovatov
* Date: 27/08/21

Technical Story: 

## Context and Problem Statement

Team is going to deploy OneSchedule application and database onto Azure cloud.
We should make a descision, which option to choose for deployment, which pricing is better 
and which functionality will cover the needs of our application/ 

## Decision Drivers

* Choose an option that provides developers with ability to use Mongo DB as application database and host it in the cloud;
* The deployment option should use less financial resources to fulfill functionality needed, if it's possible; 


## Considered Options

* Azure virtual machine
* Azure App Service / CosmosDB
* Azure Container Instances


## Decision Outcome

Chosen option: "Azure App Service / CosmosDB", because of affordable price yet matching all application needs criterias.

### Positive Consequences 

* we should get an applicationg deployed in a cloud using Mongo DB

### Negative Consequences 

* Pricing is a bit higher in comparison to ACI, but we'll get more functionality using CosmosDB;

## Pros and Cons of the Options

### Azure virtual machine

Above 100 dollars per month

* Good, because covers application requirements
* Good, well known technology
* Bad, because it needs more system resources
* Bad, because it's more expencive in comparison o competitors


### Azure App Service and CosmosDB

About 10 cents per hour + 5 dollars per month

* Good, because uses Azure DB service CosmosDB, which is designed to work with NoSQL databases like MongoDB
* Good, because covers application requirements
* Bad, because has higher price than ACI


### Azure Container Instances and Azure Container Registry

About 5 cents per hour 

* Good, because has lowest price among all options
* Good, because covers application requirements
* Bad, because demands from developers to create and upload containers with appropriate options;


## Links 

Pricing - Container instances https://azure.microsoft.com/en-us/pricing/details/container-instances/
App Service pricing https://azure.microsoft.com/en-us/pricing/details/app-service/windows/
CosmosDB pricing https://azure.microsoft.com/en-us/pricing/details/cosmos-db/
VM pricing https://azure.microsoft.com/en-us/pricing/details/virtual-machines/windows/
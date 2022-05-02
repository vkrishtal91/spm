# [DRAFT] Simple Package Management Service

The goal of the SPM to allow to get simple way to use custom packages with any data.
It can be configurations, libraries,
assets and so on. The SPM service allows user to find required package by any these attribute and download to local computer.

### What is the Package?

The package is usual archive which contains some additional meta information about a package content like version, hash, package description
and tags.
But in addition, the package can be endowed with any custom data. For example it can be git branch, tag or commit hash, author, license and
any key-value attributes.

### How to use SMP?
To working on SMP you should use small terminal tool [spt]() - simple packaging tool which was named similar with [apt](). 
Sure the apt is more powerful tool which supports features like package dependencies however some times is more useful to use more simple thik like spm + spt.


### Build and run locally

``` 
docker-compose build
docker-compose up
```

### Solution structure

* [docs]() directory contains all project documentation
    * [img]() directory contains all images for wiki
    * [md]() directory contains all markdown documents for wiki
    * [uml]() directory contains all uml diagrams to explain project architecture

* [src]() directory contains all source code
    * [Link text Here]()
        * [Link text Here]()

* [k8s]() directory contains scripts and configurations to deploy SPM services to kubernetes
    * [minikube]()
    * [production]()

* [api.dockerfile]() file to build [Spm.Web.Api]() service
* [gui.dockerfile]() file to build [Spm.Web.Gui]() service
* [docker-compose.yml]() file to build and deploy system on developer machine
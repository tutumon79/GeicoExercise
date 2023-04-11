# Unit Testing
Unit Tests can be implemented with MS Tests or NUnit. Need to setup the Test Classes. For unit testing, Projects shuold contains the Test Classes, Setup and TearDown or equivalant funtions. Try to cover all the functions in the project level and get 90% coverage at least. In our case, we can create tests for Controllers, Services, Utilities etc. Individual methods can be tested against the positive cases, negative or exception cases. Integrate the unit test with devops pipeline and add the pre-condition for the unit test success to enusre successful PR completion. Follow the Arrange, Act Asset Process flow to perfrom the unit testing.

Assumptions
1. One customer can have more than one policy.
2. Data is stored inside in-memory collection only. Using the right ORM and datastore, data can be persisted into the correct database.
3. Default geo-location classes are not utilized. I have created a custome geo-location class and add a property to hold the distance from a specific location too.
4. For the SortedSet, sorting is done based on the Disance propert mentioned in the step 3. This is helpful to find the nearest assistants from a location.
5. Not done exception handling through out. This is done in couple of places only. Relevant logging can be done on real project.
6. Service is publicly accessible to anyone. No kind of security mechanism is incorporated.
7. optional<Assitant> is implemented separately, assuming, this is something required by the geico panel.
As an alternative, cache like redis or similar tool can be used to store the data temporarily and deliver the functinality in the requirement completely. However, i choose to deliver it the current way with notes on it.

Feature: InstagramTestApi
	This is an API test to get the
	City name based on the Pincode  

@SmokeTest
Scenario Outline: Check Post Codes 
	Given The API takes the city Name and returns the Pincode
	When I have entered the <CityName>
	Then the respective <PinCode> returned should be as expected

@Source:PostCodeCity.xlsx
Scenarios:Post Code Test
|CityName|PinCode|
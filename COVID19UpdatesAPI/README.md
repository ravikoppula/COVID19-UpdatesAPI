# COVID-19 UPDATES API
## Steps to clone the source code

1. Open command prompt and navigate to the desired path.
2. Clone the source code from the github repo and copy the path below and hit Enter
                 git clone https://github.com/ravikoppula/COVID19-UpdatesAPI.git
3. Open the folder path and find COVID19UpdatesAPI.sln file. Double clicking on the file will open the solution in the visual studio 2017 or later version.

## Steps Explore project folder structure
1. Inside the COVID19UpdatesAPI Solution, controllers can be found under the controller folder (which is used for request & user response)
2. Interfaces folder contains all the interfaces which are implemented for the future.
3. Under the Models folder - View model folder and Data folder are stored
4. View Models is used to bind the output parameter.
5. Data Folder will be used to store the files (Ref: Git repo).
6. Services folder will store the logic and process HTTP response (User response).
7. View folder to design HTML pages to interact with the user.
8. Appsettings.json is used for data connection or any security tokens in the future for Git Access.
9. In Startup.cs file contains all the dependency injection (DI) which is used in the project along with the routing path for project launch.


## Steps to build and run the API solution.

1. Build the solution by hitting F6 button. Alternatively, build option can be chosen from the top menu from Visual studio.
2. Run the solution by hiting F6 button (or) Hitting on Ctrl+shift+c will allow step 1 and step 2 to build and run the solution concurrently.
3. Once the build and run is sucessful, solution will render the default setting page followed by the display of the dashboard (use GOOGLE CHROME for better optimization)
4. API is tested from the frontend by entering the country,state and date inputs.
        **Note: Country, state and Last updated date are optional fields.**


## Steps to test with the API via third party tools
1. Login to Postman Web. Please click the link below to open Postman Web. Alternatively, Postman can be downloaded directly on Windows.
Post man web - https://interstellar-flare-1652.postman.co/
2. For first-time users, please sign-in to record your activities under history session.
3. Retain the solution in run mode to receive the API call.


### Test Case 1: View data based on country and state
``` 
[https://localhost:44329/api/covidupdates/getcovidupdates?country=Brazil&amp;state=Ceara](https://localhost:44329/api/covidupdates/getcovidupdates?country=Brazil&amp;state=Ceara)

API Response:
[
    {
        &quot;province\_State&quot;: &quot;Ceara&quot;,
        &quot;country\_Region&quot;: &quot;Brazil&quot;,
        &quot;confirmed&quot;: &quot;336504&quot;,
        &quot;deaths&quot;: &quot;10004&quot;,
        &quot;recovered&quot;: &quot;269846&quot;,
        &quot;active&quot;: &quot;56153&quot;,
        &quot;lastUpdatedDate&quot;: &quot;2021-01-02T05:22:33&quot;
    },

    {
        &quot;province\_State&quot;: &quot;Ceara&quot;,
        &quot;country\_Region&quot;: &quot;Brazil&quot;,
        &quot;confirmed&quot;: &quot;336574&quot;,
        &quot;deaths&quot;: &quot;10015&quot;,
        &quot;recovered&quot;: &quot;270203&quot;,
        &quot;active&quot;: &quot;56356&quot;,
        &quot;lastUpdatedDate&quot;: &quot;2021-01-03T05:22:52&quot;
    }
]
```
### Test Case 2: View data based on country
API Request
```
https://localhost:44329/api/covidupdates/getcovidupdates?country=Brazil](https://localhost:44329/api/covidupdates/getcovidupdates?country=Brazil)

API Response:

API response is lengthy, therefore the response JSON havent attached.
```

### Test case 3: View data based on state
```
https://localhost:44329/api/covidupdates/getcovidupdates?state=Ceara](https://localhost:44329/api/covidupdates/getcovidupdates?state=Ceara)

API Response:
[

    {
        &quot;province\_State&quot;: &quot;Ceara&quot;,
        &quot;country\_Region&quot;: &quot;Brazil&quot;,
        &quot;confirmed&quot;: &quot;336504&quot;,
        &quot;deaths&quot;: &quot;10004&quot;,
        &quot;recovered&quot;: &quot;269846&quot;,
        &quot;active&quot;: &quot;56153&quot;,
        &quot;lastUpdatedDate&quot;: &quot;2021-01-02T05:22:33&quot;
    },
    {
        &quot;province\_State&quot;: &quot;Ceara&quot;,
        &quot;country\_Region&quot;: &quot;Brazil&quot;,
        &quot;confirmed&quot;: &quot;336574&quot;,
        &quot;deaths&quot;: &quot;10015&quot;,
        &quot;recovered&quot;: &quot;270203&quot;,
        &quot;active&quot;: &quot;56356&quot;,
        &quot;lastUpdatedDate&quot;, 
	    &quot;2021-01-03T05:22:52&quot;
    }

]
```
### Test case 4: View data based on date
```
API Request
https://localhost:44329/api/covidupdates/getcovidupdates?lastUpdatedDate=2021-01-02](https://localhost:44329/api/covidupdates/getcovidupdates?lastUpdatedDate=2021-01-02)
```

```
Test 4: View data without any filter:
API Request
API Request: [https://localhost:44329/api/covidupdates/getcovidupdates](https://localhost:44329/api/covidupdates/getcovidupdates)
```

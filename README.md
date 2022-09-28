# Take Home Project

<p align="left">
 This is an OpenAPI  compliant web service that abstracts away two downstream APIs; the Chuck Norris API and the Star Wars API. 
</p>
<p align="left">
This API have 3 root paths:
<ul>
<li>	/chuck </li>
<li>	/swapi </li>
<li>	/search </li>
</ul>
</p>
 <p align="left">
It has an endpoint at /chuck/categories which returns the result of https://api.chucknorris.io/jokes/categories (all the joke categories)
</p>
 <p align="left">
It has an endpoint at /swapi/people which returns the result of https://swapi.dev/api/people/ (all the Star Wars people)
</p>
 <p align="left">
It also has the /search endpoint which calls both the https://api.chucknorris.io/jokes/search?query={query} and the https://swapi.dev/api/people/?search={query}. <br>
When queried, it simultaneously search both the Chuck Norris and Star Wars API. 
</p>

##  Teknology Used
- Asp.net Core Web Api

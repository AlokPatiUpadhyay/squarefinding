
# Find Squares

## How to run application

Already added below points to database
(-1, 1), (-1, -1), (1, -1), (1, 1), (-3, 1), (-7, -1), (-4, -1), (-3, -1)

Run find squares api "/Square/find-squares" to find squares with points


## How to deploy using docker

Command to run docker instance


### Generate certificate


#### Run on http
docker build -t squarefinding .

docker run -it --rm -p 3000:80 --name squarefindinginstance1 squarefinding


#### Run on https
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p password

dotnet dev-certs https --trust

docker run --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_Kestrel__Certificates__Default__Password="password" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx -v %USERPROFILE%\.aspnet\https:/https/ --name squarefindinginstance1 squarefinding


## Find Square complexity

FindSquares method conplexity

Time complexity => 

1. Setting value to hashset will take n time 

2. Finding points 
	(n-1) + (n-2) + (n-3) + (n-4) .... +0

so
	Total Complexity = O(n) + O( n-1 + .... + 1)

formula => n/2[2a+ (n-1)*d]

where
	n= n
	a= n
	d= -1

Now calculation
	=> n/2[2n + (n-1)*-1]
	=> n/2[n+1]
final
	=> n*(n+1)/2




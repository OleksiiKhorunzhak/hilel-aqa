$URI ="https://demoqa.com/Account/v1/User/67dd8a51-278d-465a-a74b-5211e6048f66" 
$headers = @{
  #'accept' = 'application/json'
  'Authorization' = 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6Im9sbiIsInBhc3N3b3JkIjoiT2xuMTIzISoiLCJpYXQiOjE3MjQzMjAxNjZ9.EqaEcqf-6u-82G-W2J93NVwGWjHZYhIAt-Ba4phUp5o'
  }
  Invoke-WebRequest -Method 'GET' -Uri $URI -Headers $headers
  Invoke-WebRequest -Method 'DELETE' -Uri $URI -Headers $headers

var express = require('express');

var app = express();
app.engine('.html', require('ejs').__express);
app.set('views', __dirname + '/build/html');
app.set('view engine', 'ejs');

app.use(express.static(__dirname + '/build'));

app.get('/', function(req,res) { res.render('index'); });

app.listen(8888);
console.log("Running at Port 8888");

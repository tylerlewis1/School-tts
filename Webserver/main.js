const express = require('express');
const questions = require('./API/Endpoints/Question');
const app = express();
app.use('/question', questions);
module.exports = app;

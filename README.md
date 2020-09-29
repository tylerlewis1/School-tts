# School-tts
This is a TTS service ment for schools.
<br>
<h1>How it works</h1>
<br>
<p>The student gose the the website and logs in with google. They log in so the teacher knows how asked the question. Next the student will click the ask a question button and they will be prompted to enter a class code. Next they will be prompted to enter their question. Once they enter their question the website will make a POST request to the webserver with the name, question and class code. Once the web server receives the data it will put it in a log file(This is mainly for security). Next every .5 seconds the tts app makes a GET request to the webserver and seeing if the data has changed and if it has it checks for the class code. If the class code matched the one given it will use speech synthesis to speak.</p>
<br>
<h1>What the options do</h1>
<h6>Image: https://i.ibb.co/pnXXBTC/image.png</h6>
<p>The speed slider selects speed of the tts voice. <br> The volume slider selects the volume of the tts voice. <br> The voice gender dropdown selects the gender of the tts voice.<br> The mode drop down you can select blurt witch will just say the message and the wait mode will beep when you get a question and to make it say the message you can click on the repeat last question button or say "speaker speak".</p>
<br>
<h1>How to get it to work</h1>
 <br>
 <p>All you need to do to get it working is change every where it says "WEBSERVER" with your server ip and add a google api key where it says "API KEY". The https port is 25560 by default and the http port is 3000 by defualt.</p>
 <br>
 <br>
 <a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/"><img alt="Creative Commons License" style="border-width:0" src="https://i.creativecommons.org/l/by-nc-sa/4.0/88x31.png" /></a><br />This work is licensed under a <a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/">Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License</a>.

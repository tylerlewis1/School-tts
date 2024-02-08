# School-tts
This is a TTS service designed for schools.
<br>
<b>If you are interested in using this program and you want more information about it or help setting it up, You can contact me at tglewis247@gmail.com</b>
<br>
<h1>How it works</h1>
<br>
<p>The student will go to the website and log in with their Google account. The student's name is pulled from the Google account so the teacher knows who asked the question. Next, the student will click on the ask a question button and they will be prompted to enter a class code. Next, they will be prompted to enter their question into the textbox. Once they enter their question the website will make a POST request to the webserver with the name, question, and class code. Once the web server receives the data it will put it in a log file (This is mainly for security). The program on the teacher's side program will check the web server for new questions every half second. If the class code matches the one given it will use speech synthesis to speak the student's question throuh the computer speakers.</p>
<br>
<img src="https://i.ibb.co/rK9KTZ3/how-it-works.png" width=500>
<br>
<h1>What the options do</h1>
<html>
<img src="https://i.ibb.co/pnXXBTC/image.png">
</html>
<p>The speed slider selects speed of the TTS voice. <br> The volume slider selects the volume of the tts voice. <br> The voice gender dropdown selects the gender of the TTS voice.<br> The mode drop down you can select blurt witch will just say the message and the wait mode will beep when you get a question. This will make it say the message you can click on the repeat last question button or say "speaker speak".</p>
<br>
<h1>Setup</h1>
 <br>
 <p>All you need to do to get it working is change everywhere it says "WEBSERVER" (If you use the C# version you the place to change server URL is in settings.json) with your server IP and add a google API key where it says "API KEY" in the website html. The HTTPS port is 25560 by default and the HTTP port is 3000. For most cases you shoud use the https port for scurity. You can remove the HTTP port by removing the HTTP socket in the file named index.js in the webserver, you need to add your SSL private key and certificate for your domain.</p>
 <br>
 <br>
 <a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/"><img alt="Creative Commons License" style="border-width:0" src="https://i.creativecommons.org/l/by-nc-sa/4.0/88x31.png" /></a><br />This work is licensed under a <a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/">Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License</a>.

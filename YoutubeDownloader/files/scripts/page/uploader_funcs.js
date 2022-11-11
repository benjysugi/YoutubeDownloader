// JavaScript Document

function prc_youtube() {
	var uri = document.getElementById("yt_uri").value;
	//alert(uri);
	
	if(uri.includes("https://")) {
		if(uri.includes("youtube.com")) {
			if(uri.includes("watch?v=")) {
				var id = uri.substring(32);
				window.location.href = "/LinkProc/YouTube.ashx/" + id;
			}
			else {
				alert("Not a valid YouTube link");
			}
		}
		else if(uri.includes("youtu.be")) {
			var idr = uri.substring(17);
			window.location.href = "/LinkProc/YouTube.ashx/" + idr;
		}
		else {
			alert("Not a valid YouTube link");
		}
	}
	else {
		alert("Not a valid YouTube link");
	}
	
	return false;
}
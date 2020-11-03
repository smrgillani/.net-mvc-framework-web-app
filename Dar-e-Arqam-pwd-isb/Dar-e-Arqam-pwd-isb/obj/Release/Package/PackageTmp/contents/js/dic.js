var currEdit=null;
	var charSpace=String.fromCharCode(32);
	var charEnter=String.fromCharCode(13);
	var charTab=String.fromCharCode(9);
	var charNewLine='\n';
	var charColon=String.fromCharCode(58);
	var charSemiColon=String.fromCharCode(59);
	var charSingleQuote=String.fromCharCode(39);
	var charDoubleQuote=String.fromCharCode(34);
	var charFullStop=String.fromCharCode(46); //(0x06D4);
	var charComma=String.fromCharCode(44);
	var charExclaim=String.fromCharCode(33);
	
	var charPlus=String.fromCharCode(43);
	var charMinus=String.fromCharCode(45);
	var charMul=String.fromCharCode(42);
	var charDiv=String.fromCharCode(47);
	var charPrecent=String.fromCharCode(37);
	var charLeftParen=String.fromCharCode(41);
	var charRightParen=String.fromCharCode(40);
	var charEqual=String.fromCharCode(61);
	var charDecSep=String.fromCharCode(61);
	
	
	var codes= new Array();
	codes['a']=0x0627;
	codes['b']=0x0628;
	codes['c']=0x0686;
	codes['d']=0x062F;
	codes['e']=0x0639;
	codes['f']=0x0641;
	codes['g']=0x06AF;
	codes['h']=0x06BE;
	codes['i']=0x06CC;
	codes['j']=0x062C;
	codes['k']=0x06A9;
	codes['l']=0x0644;
	codes['m']=0x0645;
	codes['n']=0x0646;
	codes['o']=0x06C1;
	codes['p']=0x067E;
	codes['q']=0x0642;
	codes['r']=0x0631;
	codes['s']=0x0633;
	codes['t']=0x062A;
	codes['u']=0x0626; // hamza yeh
	codes['v']=0x0637;
	codes['w']=0x0648;
	codes['x']=0x0634;
	codes['y']=0x06D2;
	codes['z']=0x0632;
	
	codes['A']=0x0622;
	codes['B']=0x0628;
	codes['C']=0x062B;
	codes['D']=0x0688;
	codes['E']=0x0651; //tashdeed
	codes['F']=0x064D; // do zair
	codes['G']=0x063A;
	codes['H']=0x062D;
	codes['I']=0x0670; // khari zabar
	codes['J']=0x0636;
	codes['K']=0x062E;
	codes['L']=0x0628;
	codes['M']=0x064B; // do zabar
	codes['N']=0x06BA;
	codes['O']=0x0628;
	codes['P']=0x064F; // Paish
	codes['Q']=0x0628;
	codes['R']=0x0691;
	codes['S']=0x0635;
	codes['T']=0x0679;
	codes['U']=0x0621;
	codes['V']=0x0638;
	codes['W']=0x0624;
	codes['X']=0x0698;
	codes['Z']=0x0630;
	
	codes['>']=0x0650; // zair
	codes['<']=0x064E; // zabar	
	// jazm
	// do paish
	// mad
	// shad zair
	// shad paish
	// hai hamza
	// left quotation
	// right quotation
	// left double quotation
	// right double quotation

			
	codes[charSpace]=32; 
	codes[charEnter]=13;
	//codes[charTab]=String.fromCharCode(9);
	//codes[charNewLine]='\n';
	codes[charColon]=0x061B;
	codes[charSemiColon]=0x061B;
	codes[charSingleQuote]=0x2018;
	codes[charDoubleQuote]=0x201C;
	codes[charFullStop]=0x06D4;
	codes[charComma]=0x060C;
	codes[charExclaim]= 0x0021;
	codes['?']=0x061F;
	codes[':']=58;
	
	codes[charPlus]=0x002B;
	codes[charMinus]=0x002D;
	codes[charMul]=0x00D7;
	codes[charDiv]=0x00F7;
	codes[charPrecent]=0x066A;
	codes[charLeftParen]=0x0028;
	codes[charRightParen]=0x0029;
	codes[charEqual]=0x003D;

		
	codes['0']=0x660;
	codes['1']=0x661;
	codes['2']=0x662;
	codes['3']=0x663;
	codes['4']=0x664;
	codes['5']=0x665;
	codes['6']=0x666;
	codes['7']=0x667;
	codes['8']=0x668;
	codes['9']=0x669;
	
	
		
	function register(){
	if(!document.all)
	{
	var el=Form1.txt1;
	if(navigator.userAgent.toLowerCase().indexOf('chrome') == -1)
		{
		addEvent(el , "keypress",  search);
		}
	}}
	
	
	
function addEvent(obj, evType, fn){
	
  if (obj.addEventListener)
  {
    obj.addEventListener(evType, fn, true);
    return true;
  }
  else if (obj.attachEvent)
  {
	  alert("on"+evType);
    var r = obj.attachEvent("on"+evType, fn);	
    return r;
	
  }
  else
  {
    alert("Handler could not be attached");
  }
}

function subjectn(evt){
		
		//var evt=Form1.Txt1;
			evt = (evt) ? evt : (window.event) ? event : null;	
		 //var evt = event;
		 //if(!evt) evt=window.event;
	     if (evt)
  	      {
		  var charCode = (evt.charCode) ? evt.charCode :
                    ((evt.keyCode) ? evt.keyCode :
                   ((evt.which) ? evt.which : 0));
                   var whichASC = charCode ; // key's ASCII code
			var whichChar = String.fromCharCode(whichASC); // key's character


			
			if(evt.keyCode)
			{
				
				evt.keyCode= codes[whichChar];
				if(navigator.userAgent.toLowerCase().indexOf('chrome') > -1)
				{
				AddTexts( String.fromCharCode(codes[whichChar]));
				evt.preventDefault();
				evt.stopPropagation();
				}
			}
			else if(evt.which)
			{
			
				//evt.which= codes[whichChar];
				//alert('evt.which : '+whichChar);
				AddTexts( String.fromCharCode(codes[whichChar]));
				evt.preventDefault();
				evt.stopPropagation();
			}
			else if(evt.charCode)
			{
				AddTexts(whichChar);
				evt.preventDefault();
				evt.stopPropagation();				
			}
		  }
		}
function AddTexts(text) 
{
    var bbc = document.getElementById('Subject_name').value;
	 bbc=bbc+text;
	 document.getElementById('Subject_name').value = bbc;
	 document.getElementById('Subject_name').scrollTop = document.getElementById('Subject_name').scrollHeight;
}
function subjectc(evt){
		
		//var evt=Form1.Txt1;
			evt = (evt) ? evt : (window.event) ? event : null;	
		 //var evt = event;
		 //if(!evt) evt=window.event;
	     if (evt)
  	      {
		  var charCode = (evt.charCode) ? evt.charCode :
                    ((evt.keyCode) ? evt.keyCode :
                   ((evt.which) ? evt.which : 0));
                   var whichASC = charCode ; // key's ASCII code
			var whichChar = String.fromCharCode(whichASC); // key's character


			
			if(evt.keyCode)
			{
				
				evt.keyCode= codes[whichChar];
				if(navigator.userAgent.toLowerCase().indexOf('chrome') > -1)
				{
				AddText( String.fromCharCode(codes[whichChar]));
				evt.preventDefault();
				evt.stopPropagation();
				}
			}
			else if(evt.which)
			{
			
				//evt.which= codes[whichChar];
				//alert('evt.which : '+whichChar);
				AddText( String.fromCharCode(codes[whichChar]));
				evt.preventDefault();
				evt.stopPropagation();
			}
			else if(evt.charCode)
			{
				AddText(whichChar);
				evt.preventDefault();
				evt.stopPropagation();				
			}
		  }
		}
function AddText(text) 
{
    var abc = document.getElementById('Contxt').value;
	 abc=abc+text;
	 document.getElementById('Contxt').value = abc;
	 document.getElementById('Contxt').scrollTop = document.getElementById('Contxt').scrollHeight;
}		
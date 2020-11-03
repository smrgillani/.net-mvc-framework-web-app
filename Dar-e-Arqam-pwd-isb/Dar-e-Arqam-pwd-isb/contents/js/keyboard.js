
var lang = 1;	// 1: Urdu, 0: English 

var urdukey_phonetic = [
  0x0020,0x0021,0x002D,0x0023,0x064A,0x066A,0x0653,0x2024,0x0029,0x0028,0x064C,0x0653,0x060C,0x0674,0x06D4,0x002F,
0x06F0,0x06F1,0x06F2,0x06F3,0x06F4,0x06F5,0x06F6,0x06F7,0x06F8,0x06F9,0x003A,0x061B,0x0650,0x0624,0x064E,0x061F,
0x0655,0x0622,0xE000,0x062B,0x0688,0xE001,0xE003,0x063A,0x062D,0x0670,0x0636,0x062E,0xE002,0x0655,0x06BA,0x0629,
0x064F,0x0652,0x0691,0x0635,0x0679,0x0621,0x0638,0xFDFA,0x0698,0x064A,0x0630,0x0647,0xFDF2,0xE004,0x0652,0x0651,
0x064B,0x0627,0x0628,0x0686,0x062F,0x0639,0x0641,0x06AF,0x06BE,0x06CC,0x062C,0x06A9,0x0644,0x0645,0x0646,0x06C1,
0x067E,0x0642,0x0631,0x0633,0x062A,0x0626,0x0637,0x0648,0x0634,0x06D2,0x0632,0x2018,0x0674,0x2019,0x064D
];
var urdukey_urdu98 = [
0x0020,0x0021,0x0022,0x0023,0x06E4,0x066A,0x0653,0x0027,
0x0029,0x0028,0x002A,0x002B,0x060C,0x002D,0x06D4,0x002F,
0x06F0,0x06F1,0x06F2,0x06F3,0x06F4,0x06F5,0x06F6,0x06F7,
0x06F8,0x06F9,0x003A,0x061B,0xFD3E,0x003D,0xFD3F,0x061F,
0x0655,0x0650,0x0688,0xE001,0x0630,0x063A,0x064B,0x064D,
0x0622,0x0621,0x064F,0x064C,0xE004,0xFDFA,0x0691,0x0647,
0xE000,0x0624,0x0632,0x0651,0x0679,0x062E,0x0626,0x064E,
0x0636,0x064A,0x0698,0x06BE,0x0670,0x0637,0x0652,0xE003,
0x0629,0x0633,0x0628,0x062B,0x062F,0x0639,0x0641,0x06AF,
0x0627,0x06D2,0x062C,0x06A9,0x0644,0x0645,0x0646,0x06C1,
0x067E,0x0642,0x0631,0x0634,0x062A,0x062D,0x0648,0x0686,
0x0635,0x06CC,0x06BA,0xE002,0x0674,0x0638,0xFDF2
];

// on Alt+Shift, switch language
function FKeyDown()
{
   if (window.event.shiftKey && window.event.altKey) { 
      if (lang == 0) {
         lang = 1;
         window.defaultStatus = "Urdu Mode";
      }
      else {
         lang = 0;
         window.defaultStatus = "English Mode";
      }
      return false;
   }
   return true;
}

// change the Urdu
function FKeyPress()
{
   var key = window.event.keyCode;
   // Avoid processing if control or higher than ASCII (i.e., in Arabic Windows)
   if (key < 0x0020 || key >= 0x00FF)
      return;
   if (lang == 1) { //If Urdu
      if (key == 0x0020 && window.event.shiftKey) // Shift-space -> ZWNJ
         window.event.keyCode = 0x200C;
      else
         window.event.keyCode = urdukey_urdu98[key - 0x0020];
   }
   return true;
}


function LangFar (myobj)
{
       myobj.style.textAlign = "right";
       myobj.style.direction = "rtl";
       myobj.focus();
       lang = 1;
}


function LangEng (myobj)
{
       myobj.style.textAlign = "left";
       myobj.style.direction = "ltr";
       myobj.focus();
       lang = 0;
}

function hurf(alpha)
{
if (alpha=="alifmada")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "آ";

	}
if (alpha=="alif")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ا";
	}
if (alpha=="bay")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ب";
	}
if (alpha=="pay")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "پ";
	}
if (alpha=="tay")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ت";
	}
if (alpha=="thay")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ٹ";
	}
if (alpha=="say")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ث";
	}
if (alpha=="jim")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ج";
	}
if (alpha=="hay1")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ح";
	}	
if (alpha=="khay")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "خ";
	}	
if (alpha=="chay")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "چ";
	}
if (alpha=="dal")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "د";
	}
if (alpha=="dhal")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ڈ";
	}
	
if (alpha=="zal")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ذ";
	}
if (alpha=="ray")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ر";
	}
if (alpha=="zay")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ز";
	}
if (alpha=="kaf")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ک";
	}
if (alpha=="gaf")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "گ";
	}
if (alpha=="qaf")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ق";
	}
if (alpha=="fay")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ف";
	}
if (alpha=="gain")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "غ";
	}
if (alpha=="ain")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ع";
	}
if (alpha=="zhoy")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ظ";
	}
if (alpha=="thoy")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ط";
	}
if (alpha=="duad")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ض";
	}
if (alpha=="suad")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ص";
	}
if (alpha=="sheen")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ش";
	}
if (alpha=="seen")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "س";
	}
if (alpha=="zhay")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ژ";
	}
if (alpha=="rahy")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ڑ";
	}

if (alpha=="pbuh")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ﷺ";
	}
if (alpha=="Allah")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "لله";
	}
if (alpha=="bariya")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ے";
	}
if (alpha=="yamada")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ئ";
	}
if (alpha=="ya")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ی";
	}
if (alpha=="dochachmihay")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ھ";
	}
if (alpha=="hay")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ہ";
	}
if (alpha=="hamza")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ء";
	}
if (alpha=="wowmada")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ؤ";
	}
if (alpha=="wow")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "و";
	}
if (alpha=="gunah")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ں";
	}
if (alpha=="noon")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ن";
	}
if (alpha=="mim")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "م";
	}
if (alpha=="lam")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "ل";
	}
if (alpha=="space")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + " ";
	}
if (alpha=="entr")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\r";
	}
if (alpha=="bspace")
	{
		varbk = document.getElementById('Subject_name').value;
		varbk = varbk.substring(0,varbk.length-1);
		document.getElementById('Subject_name').value= varbk;
	}
if (alpha=="dash")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "۔";
	}

	if (alpha=="salam")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rاسلام علیکم";
	}
	if (alpha=="دل کی گہرائیوں سے دلی عید مبارک")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rدل کی گہرائیوں سے دلی عید مبارک۔";
	}
	
	if (alpha=="ہم سب کی طرف سے دلی عید مبارک")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rہم سب کی طرف سے دلی عید مبارک۔";
	}
	if (alpha=="آپ کو نیک دعاؤں اور تمناؤں کے ساتھ عید مبارک")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rآپ کو نیک دعاؤں اور تمناؤں کے ساتھ عید مبارک۔";
	}	
	if (alpha=="آپ کو خوشیوں سے بھرپور عید مبارک ہو")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rآپ کو خوشیوں سے بھرپور عید مبارک ہو۔";
	}
		if (alpha=="رحمتوں اور برکتوں والا مہینہ مبارک ہو")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rرحمتوں اور برکتوں والا مہینہ مبارک ہو۔";
	}
		if (alpha=="مغفرتوں والا مہینہ مبارک ہو")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rمغفرتوں والا مہینہ مبارک ہو۔";
	}
	if (alpha=="اﷲ آپ کو اس مہینے میں ہزاروں خوشیاں عطا فرمائے")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rاﷲ آپ کو اس مہینے میں ہزاروں خوشیاں عطا فرمائے۔";
	}
	if (alpha=="اﷲ آپ کو اس مہینے میں ہزاروں برکتیں و نعمتیں عطا فرمائے")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rاﷲ آپ کو اس مہینے میں ہزاروں برکتیں و نعمتیں عطا فرمائے۔";
	}
	if (alpha=="سالگرہ مبارک")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rسالگرہ مبارک";
	}
	if (alpha=="آپ کو سالگرہ کا دن مبارک ہو")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rآپ کو سالگرہ کا دن مبارک ہو";
	}
	if (alpha=="میری دعا ہے کہ آپ کو ہزاروں سالگرہ نصیب ہوں")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rمیری دعا ہے کہ آپ کو ہزاروں سالگرہ نصیب ہوں";
	}
	if (alpha=="مجھے امید ہے آپ کی زندگی ہمیشہ خوشیوں سے بھری ہوگی")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rمجھے امید ہے آپ کی زندگی ہمیشہ خوشیوں سے بھری ہوگی";
	}
	if (alpha=="کاش آپ ابھی میری زندگی میں آجاؤ")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rکاش آپ ابھی میری زندگی میں آجاؤ";
	}
	if (alpha=="آپ کی یاد دل کو تڑپا رہی ہے")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rآپ کی یاد دل کو تڑپا رہی ہے";
	}
	if (alpha=="آدھے آدھے تھے ہم دونوں مل جاتے تو پورے ہوتے")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rآدھے آدھے تھے ہم دونوں\rمل جاتے تو پورے ہوتے";
	}
	if (alpha=="آپ کی نظرِ کرم کا شکریہ")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rآپ کی نظرِ کرم کا شکریہ";
	}
	if (alpha=="ہمیں یاد کرنے پر دل و جان سے آپ کا شکریہ")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rہمیں یاد کرنے پر دل و جان سے آپ کا شکریہ";
	}
	if (alpha=="میں بہت خوش قسمت ہوں کہ مجھے آپ جیسا بہترین دوست ملا")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rمیں بہت خوش قسمت ہوں کہ مجھے آپ جیسا بہترین دوست ملا";
	}
	if (alpha=="میں اﷲ سے دعا کرتا ہوں کہ میری اور آپ کی دوستی ہمیشہ سلامت رہے")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rمیں اﷲ سے دعا کرتا ہوں کہ میری اور آپ کی دوستی ہمیشہ سلامت رہے";
	}
	if (alpha=="خدا کرے میری اور آپ کی دوستی کو کسی کی نظر نہ لگے")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rخدا کرے میری اور آپ کی دوستی کو کسی کی نظر نہ لگے";
	}
	if (alpha=="آپ کو یہ کامیابی مبارک ہو")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rآپ کو یہ کامیابی مبارک ہو";
	}
	if (alpha=="اﷲ آپ کو ایسی ہزار کامیابیاں عطا فرمائے")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rاﷲ آپ کو ایسی ہزار کامیابیاں عطا فرمائے";
	}
	
	
	
	if (alpha=="جانتا ہوں آپ کا دل بہت بڑا ہے اس لیے آپ میری خطا کو نظر انداز کر کے مجھے معاف کر دیں گے")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rجانتا ہوں آپ کا دل بہت بڑا ہے اس لیے آپ میری خطا کو نظر انداز کر کے مجھے معاف کر دیں گے";
	}
	if (alpha=="آپ بہت اچھے ہیں آپ سے معافی کی امید رکھتا ہوں")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rآپ بہت اچھے ہیں آپ سے معافی کی امید رکھتا ہوں";
	}
	if (alpha=="میں اپنی خطا مانتے ہوئے آپ سے معافی کا طلبگار ہوں")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rمیں اپنی خطا مانتے ہوئے آپ سے معافی کا طلبگار ہوں";
	}
	
	if (alpha=="میں دعا گو ہوں کہ آپ ہمیشہ مسکراہٹوں کے موتی بکھیرتے رہیں")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rمیں دعا گو ہوں کہ آپ ہمیشہ مسکراہٹوں کے موتی بکھیرتے رہیں";
	}
	if (alpha=="زندگی ہمیشہ آپ کی مسکراتے ہوئے گزرے")
	{
		document.getElementById('Subject_name').value=document.getElementById('Subject_name').value + "\rزندگی ہمیشہ آپ کی مسکراتے ہوئے گزرے";
	}
	
	
	
	
	
	
	
	if (alpha=="ہم سب کی طرف سے آپکو عید مبارک")
	{
		document.getElementById('Subject_name').value="ہم سب کی طرف سے آپکو عید مبارک";
	}
	if (alpha=="ہم سب کی طرف سے آپکو عید مبارک")
	{
		document.getElementById('Subject_name').value="ہم سب کی طرف سے آپکو عید مبارک";
	}
	if (alpha=="ہم سب کی طرف سے آپکو عید مبارک")
	{
		document.getElementById('Subject_name').value="ہم سب کی طرف سے آپکو عید مبارک";
	}
	if (alpha=="ہم سب کی طرف سے آپکو عید مبارک")
	{
		document.getElementById('Subject_name').value="ہم سب کی طرف سے آپکو عید مبارک";
	}
	if (alpha=="دل کی گہرائیوں سے عید مبارک")
	{
		document.getElementById('Subject_name').value="دل کی گہرائیوں سے عید مبارک";
	}
	if (alpha=="ہم سب کی طرف سے دلی عید مبارک")
	{
		document.getElementById('Subject_name').value="ہم سب کی طرف سے دلی عید مبارک";
	}
	if (alpha=="نیک تمناؤں کے ساتھ عید مبارک")
	{
		document.getElementById('Subject_name').value="نیک تمناؤں کے ساتھ عید مبارک";
	}
	if (alpha=="آپ کو خوشیوں بھری عید مبارک ہو")
	{
		document.getElementById('Subject_name').value="آپ کو خوشیوں بھری عید مبارک ہو";
	}
}




function hurfs(alpha)
{
if (alpha=="alifmada")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "آ";
	}
if (alpha=="alif")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ا";
	}
if (alpha=="bay")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ب";
	}
if (alpha=="pay")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "پ";
	}
if (alpha=="tay")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ت";
	}
if (alpha=="thay")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ٹ";
	}
if (alpha=="say")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ث";
	}
if (alpha=="jim")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ج";
	}
if (alpha=="hay1")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ح";
	}	
if (alpha=="khay")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "خ";
	}	
if (alpha=="chay")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "چ";
	}
if (alpha=="dal")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "د";
	}
if (alpha=="dhal")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ڈ";
	}
	
if (alpha=="zal")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ذ";
	}
if (alpha=="ray")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ر";
	}
if (alpha=="zay")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ز";
	}
if (alpha=="kaf")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ک";
	}
if (alpha=="gaf")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "گ";
	}
if (alpha=="qaf")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ق";
	}
if (alpha=="fay")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ف";
	}
if (alpha=="gain")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "غ";
	}
if (alpha=="ain")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ع";
	}
if (alpha=="zhoy")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ظ";
	}
if (alpha=="thoy")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ط";
	}
if (alpha=="duad")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ض";
	}
if (alpha=="suad")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ص";
	}
if (alpha=="sheen")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ش";
	}
if (alpha=="seen")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "س";
	}
if (alpha=="zhay")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ژ";
	}
if (alpha=="rahy")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ڑ";
	}

if (alpha=="pbuh")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ﷺ";
	}
if (alpha=="Allah")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "لله";
	}
if (alpha=="bariya")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ے";
	}
if (alpha=="yamada")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ئ";
	}
if (alpha=="ya")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ی";
	}
if (alpha=="dochachmihay")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ھ";
	}
if (alpha=="hay")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ہ";
	}
if (alpha=="hamza")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ء";
	}
if (alpha=="wowmada")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ؤ";
	}
if (alpha=="wow")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "و";
	}
if (alpha=="gunah")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ں";
	}
if (alpha=="noon")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ن";
	}
if (alpha=="mim")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "م";
	}
if (alpha=="lam")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "ل";
	}
if (alpha=="space")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + " ";
	}
if (alpha=="entr")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\r";
	}
if (alpha=="bspace")
	{
		varbk = document.getElementById('Contxt').value;
		varbk = varbk.substring(0,varbk.length-1);
		document.getElementById('Contxt').value= varbk;
	}
if (alpha=="dash")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "۔";
	}

	if (alpha=="salam")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rاسلام علیکم";
	}
	if (alpha=="دل کی گہرائیوں سے دلی عید مبارک")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rدل کی گہرائیوں سے دلی عید مبارک۔";
	}
	
	if (alpha=="ہم سب کی طرف سے دلی عید مبارک")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rہم سب کی طرف سے دلی عید مبارک۔";
	}
	if (alpha=="آپ کو نیک دعاؤں اور تمناؤں کے ساتھ عید مبارک")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rآپ کو نیک دعاؤں اور تمناؤں کے ساتھ عید مبارک۔";
	}	
	if (alpha=="آپ کو خوشیوں سے بھرپور عید مبارک ہو")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rآپ کو خوشیوں سے بھرپور عید مبارک ہو۔";
	}
		if (alpha=="رحمتوں اور برکتوں والا مہینہ مبارک ہو")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rرحمتوں اور برکتوں والا مہینہ مبارک ہو۔";
	}
		if (alpha=="مغفرتوں والا مہینہ مبارک ہو")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rمغفرتوں والا مہینہ مبارک ہو۔";
	}
	if (alpha=="اﷲ آپ کو اس مہینے میں ہزاروں خوشیاں عطا فرمائے")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rاﷲ آپ کو اس مہینے میں ہزاروں خوشیاں عطا فرمائے۔";
	}
	if (alpha=="اﷲ آپ کو اس مہینے میں ہزاروں برکتیں و نعمتیں عطا فرمائے")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rاﷲ آپ کو اس مہینے میں ہزاروں برکتیں و نعمتیں عطا فرمائے۔";
	}
	if (alpha=="سالگرہ مبارک")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rسالگرہ مبارک";
	}
	if (alpha=="آپ کو سالگرہ کا دن مبارک ہو")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rآپ کو سالگرہ کا دن مبارک ہو";
	}
	if (alpha=="میری دعا ہے کہ آپ کو ہزاروں سالگرہ نصیب ہوں")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rمیری دعا ہے کہ آپ کو ہزاروں سالگرہ نصیب ہوں";
	}
	if (alpha=="مجھے امید ہے آپ کی زندگی ہمیشہ خوشیوں سے بھری ہوگی")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rمجھے امید ہے آپ کی زندگی ہمیشہ خوشیوں سے بھری ہوگی";
	}
	if (alpha=="کاش آپ ابھی میری زندگی میں آجاؤ")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rکاش آپ ابھی میری زندگی میں آجاؤ";
	}
	if (alpha=="آپ کی یاد دل کو تڑپا رہی ہے")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rآپ کی یاد دل کو تڑپا رہی ہے";
	}
	if (alpha=="آدھے آدھے تھے ہم دونوں مل جاتے تو پورے ہوتے")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rآدھے آدھے تھے ہم دونوں\rمل جاتے تو پورے ہوتے";
	}
	if (alpha=="آپ کی نظرِ کرم کا شکریہ")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rآپ کی نظرِ کرم کا شکریہ";
	}
	if (alpha=="ہمیں یاد کرنے پر دل و جان سے آپ کا شکریہ")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rہمیں یاد کرنے پر دل و جان سے آپ کا شکریہ";
	}
	if (alpha=="میں بہت خوش قسمت ہوں کہ مجھے آپ جیسا بہترین دوست ملا")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rمیں بہت خوش قسمت ہوں کہ مجھے آپ جیسا بہترین دوست ملا";
	}
	if (alpha=="میں اﷲ سے دعا کرتا ہوں کہ میری اور آپ کی دوستی ہمیشہ سلامت رہے")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rمیں اﷲ سے دعا کرتا ہوں کہ میری اور آپ کی دوستی ہمیشہ سلامت رہے";
	}
	if (alpha=="خدا کرے میری اور آپ کی دوستی کو کسی کی نظر نہ لگے")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rخدا کرے میری اور آپ کی دوستی کو کسی کی نظر نہ لگے";
	}
	if (alpha=="آپ کو یہ کامیابی مبارک ہو")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rآپ کو یہ کامیابی مبارک ہو";
	}
	if (alpha=="اﷲ آپ کو ایسی ہزار کامیابیاں عطا فرمائے")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rاﷲ آپ کو ایسی ہزار کامیابیاں عطا فرمائے";
	}
	
	
	
	if (alpha=="جانتا ہوں آپ کا دل بہت بڑا ہے اس لیے آپ میری خطا کو نظر انداز کر کے مجھے معاف کر دیں گے")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rجانتا ہوں آپ کا دل بہت بڑا ہے اس لیے آپ میری خطا کو نظر انداز کر کے مجھے معاف کر دیں گے";
	}
	if (alpha=="آپ بہت اچھے ہیں آپ سے معافی کی امید رکھتا ہوں")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rآپ بہت اچھے ہیں آپ سے معافی کی امید رکھتا ہوں";
	}
	if (alpha=="میں اپنی خطا مانتے ہوئے آپ سے معافی کا طلبگار ہوں")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rمیں اپنی خطا مانتے ہوئے آپ سے معافی کا طلبگار ہوں";
	}
	
	if (alpha=="میں دعا گو ہوں کہ آپ ہمیشہ مسکراہٹوں کے موتی بکھیرتے رہیں")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rمیں دعا گو ہوں کہ آپ ہمیشہ مسکراہٹوں کے موتی بکھیرتے رہیں";
	}
	if (alpha=="زندگی ہمیشہ آپ کی مسکراتے ہوئے گزرے")
	{
		document.getElementById('Contxt').value=document.getElementById('Contxt').value + "\rزندگی ہمیشہ آپ کی مسکراتے ہوئے گزرے";
	}
	
	
	
	
	
	
	
	if (alpha=="ہم سب کی طرف سے آپکو عید مبارک")
	{
		document.getElementById('Contxt').value="ہم سب کی طرف سے آپکو عید مبارک";
	}
	if (alpha=="ہم سب کی طرف سے آپکو عید مبارک")
	{
		document.getElementById('Contxt').value="ہم سب کی طرف سے آپکو عید مبارک";
	}
	if (alpha=="ہم سب کی طرف سے آپکو عید مبارک")
	{
		document.getElementById('Contxt').value="ہم سب کی طرف سے آپکو عید مبارک";
	}
	if (alpha=="ہم سب کی طرف سے آپکو عید مبارک")
	{
		document.getElementById('Contxt').value="ہم سب کی طرف سے آپکو عید مبارک";
	}
	if (alpha=="دل کی گہرائیوں سے عید مبارک")
	{
		document.getElementById('Contxt').value="دل کی گہرائیوں سے عید مبارک";
	}
	if (alpha=="ہم سب کی طرف سے دلی عید مبارک")
	{
		document.getElementById('Contxt').value="ہم سب کی طرف سے دلی عید مبارک";
	}
	if (alpha=="نیک تمناؤں کے ساتھ عید مبارک")
	{
		document.getElementById('Contxt').value="نیک تمناؤں کے ساتھ عید مبارک";
	}
	if (alpha=="آپ کو خوشیوں بھری عید مبارک ہو")
	{
		document.getElementById('Contxt').value="آپ کو خوشیوں بھری عید مبارک ہو";
	}
}



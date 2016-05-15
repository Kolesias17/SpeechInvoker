using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Threading;
using System.Windows.Forms;

namespace SpeechDota
{
	public partial class Form1 : Form
	{
		Choices commands;
		Grammar grammar;

		SpeechRecognitionEngine recognizer;
		GrammarBuilder gBuilder	= new GrammarBuilder();

		[DllImport( "user32.dll" )]
		public static extern int SetForegroundWindow( IntPtr hWnd );

		[DllImport( "user32.dll" )]
		public static extern bool SendMessage( IntPtr hWnd, UInt32 Msg, int wParam, int lParam );

		const UInt32 WM_KEYDOWN = 0x0100;
		const UInt32 WM_KEYUP = 0x0101;
		const UInt32 WM_CHAR = 0x0102;

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load( object sender, EventArgs e ) {
			// Creamos el motor de reconocimiento
			recognizer = new SpeechRecognitionEngine( CultureInfo.InstalledUICulture );

			// Comandos válidos
			commands = new Choices();
			commands.Add( "congelación" );
			commands.Add( "congela" );
			//commands.Add( "stun" );
			commands.Add( "fantasma" );
			commands.Add( "muro" );
			commands.Add( "muro de hielo" );
			commands.Add( "pem" );
			commands.Add( "tornado" );
			commands.Add( "presteza" );
			commands.Add( "impacto" );
			commands.Add( "espíritu" );
			commands.Add( "meteoro" );
			commands.Add( "metorito" );
			commands.Add( "explosión" );

			// Creamos el dirección de gramatica
			gBuilder.Append( commands );
			gBuilder.Culture = CultureInfo.InstalledUICulture;

			grammar = new Grammar( gBuilder );

			// Lo usamos
			recognizer.LoadGrammar( grammar );
			recognizer.SetInputToDefaultAudioDevice();

			recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>( onSpeech );
		}

		/// <summary>
		/// Envía un comando a la VConsole
		/// </summary>
		/// <param name="command">Comando</param>
		public void sendVConsole( string command ) {
			try {
				// Buscamos el proceso del vConsole2
				Process vConsole = Process.GetProcessesByName( "vconsole2" )[0];
				Process dota = Process.GetProcessesByName( "DOTA2" )[0];

				// Mandamos cada letra a la ventana de vconsole
				foreach ( char c in command ) {
					SetForegroundWindow( vConsole.MainWindowHandle );
					SendMessage( vConsole.MainWindowHandle, WM_CHAR, (int)c, 0 );
				}

				// Enter!
				SendMessage( vConsole.MainWindowHandle, WM_KEYDOWN, 13, 0 );
				SetForegroundWindow( dota.MainWindowHandle );

				// Quickcast
				// Debemos esperar 60ms para que la habilidad se ponga en el slot 3
				if ( quickCast.Checked && command != "dota_ability_quickcast 3" ) {
					Thread.Sleep( 60 );
					sendVConsole( "dota_ability_quickcast 3" );
				}
			}
			catch( Exception e ) {
				MessageBox.Show( "No se ha iniciado vconsole2.exe o dota2.exe", "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error );
				Application.Exit();
			}
		}

		public void onSpeech( object sender, SpeechRecognizedEventArgs e ) {
			switch ( e.Result.Text ) {
				case "congelación":
				case "congela":
				case "stun":
					sendVConsole( "dota_ability_quickcast 0; dota_ability_quickcast 0; dota_ability_quickcast 0; dota_ability_quickcast 5" );
					break;

				case "fantasma":
					sendVConsole( "dota_ability_quickcast 0; dota_ability_quickcast 0; dota_ability_quickcast 1; dota_ability_quickcast 5" );
					break;

				case "muro":
				case "muro de hielo":
					sendVConsole( "dota_ability_quickcast 0; dota_ability_quickcast 0; dota_ability_quickcast 2; dota_ability_quickcast 5" );
					break;

				case "pem":
					sendVConsole( "dota_ability_quickcast 1; dota_ability_quickcast 1; dota_ability_quickcast 1; dota_ability_quickcast 5" );
					break;

				case "tornado":
					sendVConsole( "dota_ability_quickcast 1; dota_ability_quickcast 1; dota_ability_quickcast 0; dota_ability_quickcast 5" );
					break;

				case "presteza":
					sendVConsole( "dota_ability_quickcast 1; dota_ability_quickcast 1; dota_ability_quickcast 2; dota_ability_quickcast 5" );
					break;

				case "impacto":
					sendVConsole( "dota_ability_quickcast 2; dota_ability_quickcast 2; dota_ability_quickcast 2; dota_ability_quickcast 5" );
					break;

				case "espíritu":
					sendVConsole( "dota_ability_quickcast 2; dota_ability_quickcast 2; dota_ability_quickcast 0; dota_ability_quickcast 5" );
					break;

				case "meteoro":
				case "metorito":
					sendVConsole( "dota_ability_quickcast 2; dota_ability_quickcast 2; dota_ability_quickcast 1; dota_ability_quickcast 5" );
					break;

				case "explosión":
					sendVConsole( "dota_ability_quickcast 2; dota_ability_quickcast 2; dota_ability_quickcast 0; dota_ability_quickcast 5" );
					break;

				default:
					MessageBox.Show( e.Result.Text, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning );
					break;
			}

			logBox.Text = e.Result.Text + "\r\n" + logBox.Text;
		}

		private void enableBtn_Click( object sender, EventArgs e ) {
			enableBtn.Enabled = false;
			logBox.Visible = true;

			// Ejecutamos invoker.cfg
			sendVConsole( "exec invoker" );

			recognizer.RecognizeAsync( RecognizeMode.Multiple );
		}
	}
}

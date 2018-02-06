using System.Collections.Generic;
public static class StringGenerator {
	private static string axiom = "X";
	private static int iterations = 6;
	private static Dictionary<char,string> rules = new Dictionary<char,string> {
		{ 'X',"F[-X][X]F[-X]+FX" },
		{ 'F',"FF" }
	};
	public static string GenerateCommand() {
		string sentence = axiom;
		for(int i = 0;i < iterations;i++) {
			string newSentence = "";
			foreach(char c in sentence.ToCharArray()) {
				if(rules.ContainsKey(c)) newSentence += rules[c];
				else newSentence += c.ToString();
			}
			sentence = newSentence;
		}
		return sentence;
	}
}
using System.Collections.Generic;
public static class StringGenerator {
	private static string axiom = "[N]++[N]++[N]++[N]++[N]";
	private static int iterations = 4;
	private static Dictionary<char,string> rules = new Dictionary<char,string> {
		{ 'M',"OA++PA----NA[-OA----MA]++" },
		{ 'N',"+OA--PA[---MA--NA]+"},
		{ 'O',"-MA++NA[+++OA++PA]-"},
		{ 'P',"--OA++++MA[+PA++++NA]--NA" },
		{ 'A',""}
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
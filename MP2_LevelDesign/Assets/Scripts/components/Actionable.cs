public interface Actionable {
	void AddAction(Actions actionName, Handler action);
	void ExecuteAction(Actions actionName);
}

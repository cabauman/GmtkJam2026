# 🛠 Unity Smart Merge

Unity Smart Merge (also known as **UnityYAMLMerge**) helps resolve merge conflicts in Unity scene and prefab files.

---

## Configure Git to Use Unity Smart Merge

Copy and paste the following into your local `.git/config` file:

```txt
[merge]
    tool = unityyamlmerge
[mergetool "unityyamlmerge"]
    trustExitCode = true
    # Mac: /Applications/Unity/Hub/Editor/6000.3.20f1/Unity.app/Contents/Tools/UnityYAMLMerge
    cmd = 'C:/Program Files/Unity/Hub/Editor/6000.3.20f1/Editor/Data/Tools/UnityYAMLMerge.exe' merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
[mergetool]
    keepBackup = false
 ```

## 🔧 Configuring Fallback Merge Tool (Optional)

Unity Smart Merge references a file called `mergespecfile.txt` located in:

- **Windows:** `C:/Program Files/Unity/Hub/Editor/6000.3.20f1/Editor/Data/Tools/mergespecfile.txt`
- **macOS:** `/Applications/Unity/Hub/Editor/6000.3.20f1/Unity.app/Contents/Tools/mergespecfile.txt`

This file defines which external merge tools are used when Smart Merge cannot resolve conflicts.

---

### Example: Use VS Code or Rider as Fallback

1. Open `mergespecfile.txt` in a text editor.
2. Replace the following lines

```txt
unity use "%programs%\YouFallbackMergeToolForScenesHere.exe" "%l" "%r" "%b" "%d"
prefab use "%programs%\YouFallbackMergeToolForPrefabsHere.exe" "%l" "%r" "%b" "%d"
```

with

```txt
unity use "C:/Users/<YourUsername>/AppData/Local/Programs/Microsoft VS Code/Code.exe" --wait --merge "%l" "%r" "%b" "%d"
prefab use "C:/Users/<YourUsername>/AppData/Local/Programs/Microsoft VS Code/Code.exe" --wait --merge "%l" "%r" "%b" "%d"
```

OR

```txt
unity use "%ProgramFiles%/JetBrains/JetBrains Rider 2025.2.0.1/bin/rider64.exe" merge "%l" "%r" "%b" "%d"
prefab use "%ProgramFiles%/JetBrains/JetBrains Rider 2025.2.0.1/bin/rider64.exe" merge "%l" "%r" "%b" "%d"
```

## Workflow

When a merge conflict occurs in a Unity scene/prefab file run:

```bash
git mergetool
```

Smart Merge attempts to auto-resolve conflicts.
- If successful, the merged file is saved.
- If not, the fallback tool (e.g., VS Code) opens for manual resolution.

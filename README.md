# Unity 3D Project Template 2021.3

A project template that includes the correct .gitignore and .gitattributes files as well as this README.md MarkDown file. You won't see these files because they are invisible, but they help GIT work well with Unity projects.

The other major thing that this template accomplishes is that it **removes Plastic SCM from the Unity Project**, which is extremely helpful for allowing Git to work well.

*I hope this template works for you. If it doesn't, please let me know on Piazza. – Jeremy*

## Connecting GitHub Desktop to GitLab.MSU.edu Projects
In MSU Media+Information classes, I recommend using **GitHub Desktop** ([https://desktop.github.com/](https://desktop.github.com/)) to manage your GIT repos. However, doing so does require some (annoying) initial setup. *Thank you to Chris Cardimen for posting these setup steps to the MI 497 Discord channel.*

1. Download GitHub Desktop: [**https://desktop.github.com/**](https://desktop.github.com/)
2. Sign in using whatever GitHub account you prefer, I'm using my school GitHub account. You can't sign in with your GitLab account, this is a GitHub application. Linking the two comes after. If you don't have a GitHub account, you can make one for free [**here**](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account) by clicking the **Sign up** button at the top and following the directions.
3. [Login to **GitLab.msu.edu** on a web browser](http://gitlab.msu.edu).
4. Click **'Preferences'** under your profile picture (which is in the top-right corner of the screen).
5. On the lefthand sidebar, click **'Access Tokens'**
	1. Type in a **Token name** (it can be anything).
	2. Leave the **Expiration date** blank
	3. Under **Select scopes** select only **'api'**.
	4. Click **Create personal access token**.
6. You'll get a popup telling you the token ID. **_You ONLY get to see this token ID once. Copy and paste it somewhere or WRITE IT DOWN!!_**
7. **To clone a project into GitHub Desktop:**
	1. Go to the main GitLab repository page (e.g., gitlab.msu.edu/mi231-f22/[your name]/[project name]) and click **'Clone'**.
	2. Click the clipboard copy icon next to **'Clone with HTTPS'** to copy the link.
	3. Return to **GitHub Desktop**. From the **File** menu, choose **'Clone Repository** or click the **'Clone Repository'** button.
	4. Click the **URL** tab.
	5. Input the HTTPS link that you just copied as the Repository URL.
	6. Choose whatever local path you want *(I recommend your 'MI 231' folder on your computer)*.
	7. Click **'Clone'**.
	8. It's going to prompt you for login information.
		* For username, use your GitLab username (e.g., gameprof@msu.edu).
		* For the passcode/password/auth token, use the copied token from step 6. 
	9. You should be good to go! 
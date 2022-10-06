#!/bin/sh
#"mailiu@usc.edu""pocky1023""764151571@qq.com"
#"shuyuzhao@Shuyus-Air.attlocal.net""Shuyuzhaooo""112579555+Shuyuzhaooo@users.noreply.github.com"
git filter-branch --env-filter '
OLD_EMAIL="mailiu@usc.edu"
CORRECT_NAME="pocky1023"
CORRECT_EMAIL="764151571@qq.com"
if [ "$GIT_COMMITTER_EMAIL" = "$OLD_EMAIL" ]
then
    export GIT_COMMITTER_NAME="$CORRECT_NAME"
    export GIT_COMMITTER_EMAIL="$CORRECT_EMAIL"
fi
if [ "$GIT_AUTHOR_EMAIL" = "$OLD_EMAIL" ]
then
    export GIT_AUTHOR_NAME="$CORRECT_NAME"
    export GIT_AUTHOR_EMAIL="$CORRECT_EMAIL"
fi
' --tag-name-filter cat -- --branches --tags
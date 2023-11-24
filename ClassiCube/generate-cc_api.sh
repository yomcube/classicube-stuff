#!/usr/bin/bash

mkdir "cc_api" 2>/dev/null

cd src/
grep "CC_API" *.h --exclude="Core.h" | awk -F'(' '{print $1}' | sed 's/CC_API//g' | sed 's/STRING_REF //g' > "../cc_api/cc_api-0.txt"
cd ../cc_api
cat "cc_api-0.txt" | sed 's/  / /g' | sed 's/:/\n\t/g' | sed 's/\t /\t/g' > "cc_api-1.txt" # Formatting

mkdir "h" 2>/dev/null
echo "" > "cc_api-2.txt"
rm "cc_api-2.txt"
while IFS= read -r line; do
    if [[ "$line" == *.h ]]; then
    	if [ -e "h/$line" ]; then echo "">/dev/null;
    	else	
    		echo "" > "h/$line"
    		echo "$line" >> "cc_api-2.txt"
    	fi
    else
    	echo "$line" >> "cc_api-2.txt"
    fi	
done < "cc_api-1.txt"

rm -rf "h"
rm -f "cc_api-0.txt" "cc_api-1.txt"
mv "cc_api-2.txt" "../cc_api.txt"
cd ../
rmdir "cc_api"
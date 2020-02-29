
import numpy as np
import pytesseract
import argparse
import cv2
from PIL import Image
import Levenshtein
import string
from nltk.corpus import wordnet
from nltk.corpus import stopwords
stopwords = stopwords.words('english')
from py_thesaurus import Thesaurus


def similarityScore(strlist, keywordlist):
    threshold = 0.5
    score = 0
    for word in strlist:
        for keyword1 in keywordlist:
            distance = Levenshtein.distance(word, keyword1)
            if distance<threshold*len(word):
                score += len(word)*threshold-distance
    if len(strlist) == 0:
        return 0
    score /= len(strlist)
    score /= len(keywordlist)
    return score

def similarityScores(str, keywordlists):

    str = ''.join([word for word in str if word not in string.punctuation])
    str = str.lower()
    str = [word for word in str.split() if word not in stopwords]
    
    maxscore = 0
    whichindex = -1
    for keywordlistindex in range(len(keywordlists)):
        keywordlist = keywordlists[keywordlistindex]
        score = similarityScore(str, keywordlist)
        if score>maxscore:
            maxscore = score
            whichindex = keywordlistindex
    return whichindex

def enrich(keywords):
    newkeywords = keywords.copy()


    for keyword in keywords:
        synonyms = [] 
#        antonyms = [] 
  
        for syn in wordnet.synsets(keyword): 
            for l in syn.lemmas(): 
                synonyms.append(l.name()) 
#                if l.antonyms(): 
#                    antonyms.append(l.antonyms()[0].name())

        newkeywords.extend(synonyms)
#        newkeywords.extend(antonyms)

    return newkeywords


#print(enrich(["Literature", "Style", "Essay"]))

str = "Developing Efficient Algorithms Quiz Review "
keywordslist = [["Literature", "Style", "Essay"], ["algorithms", "efficiency", "Big-O"], ["Inhibit", "Zero", "Cells", "Coronavirus", "genetics"]]
#keywordslist = [keywords for keywords in keywordslist]
keywordslist = [enrich(keywords) for keywords in keywordslist]
subjects = ["English", "Computer Science", "Biology", "Unknown"]
#print(subjects[similarityScores("nil die", keywordslist)])


cap = cv2.VideoCapture(1)
width = 640
height = 480

#period is time between checks
period = 50


while(True):
    scores = [0 for subject in subjects]

    for checks in range(5):
        cv2.waitKey(period)
        ret, frame = cap.read()
        gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
        
        text = pytesseract.image_to_string(gray)
    
        cv2.imshow('frame', gray)
#        print(text)
        score = similarityScores(text, keywordslist)
        scores[score] = scores[score] + 1
    
    print(subjects[scores.index(max(scores))])
    
    if cv2.waitKey(1) and 0xFF == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()

ap = argparse

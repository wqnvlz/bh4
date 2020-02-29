import textrecognition
#import arduino_comms
#import client
#import constants
#import server
#import ultrasonic

#if relatedterms list is blank, we use dictionary
def start(subjects, relatedterms):
    if len(relatedterms) == 0:
        relatedterms = [wikicheck.getFromWiki(subject) for subject in subjects[0:(len(subjects)-1)]]
    else:
        relatedterms = [textrecognition.enrich(rlist) for rlist in relatedterms]
    
    textrecognition.startCap()
 
    while True:
        #category is the number, subject is the name
        whichcategory = textrecognition.getSubject(subjects, relatedterms)
        print(subjects[whichcategory])

subjects = ["English", "Computer Science", "Biology", "Unknown"]
relatedterms = [["Literature", "Style", "Essay"], ["algorithms", "efficiency", "Big-O"], ["Inhibit", "Zero", "Cells", "Coronavirus", "genetics"]]
start(subjects, relatedterms)

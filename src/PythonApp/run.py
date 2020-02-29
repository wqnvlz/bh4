import textrecognition
#import arduino_comms
#import client
#import constants
#import server
#import ultrasonic

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
    return subjects[whichcategory]



#subjects is 3 things, related terms is two (because one subject is unknown)
def run(subjects,relatedTerms):
    try:
        ppop={
            subjects[0]:0,
            subjects[1]:1,
            subjects[2]:2
        }
        cat=start(subjects,relatedTerms)
        num=ppop[cat]
        arduino_comms.runProcedure(num)
        return True
    except:
        return False

